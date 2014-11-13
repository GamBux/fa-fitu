-------------------
-------------------
--	Fa-fitu 
--	Database physical model
--	Piotr Nalewja 2014 - Now
-------------------
-------------------


-- Need to change UID - remove it and name should be PK
--
--
--

/*////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
///			   Table Definitions
*/			 

DROP TABLE IF EXISTS Users CASCADE;
DROP TABLE IF EXISTS Foods CASCADE;
DROP TABLE IF EXISTS IsPart CASCADE;
DROP TABLE IF EXISTS Eaten CASCADE;
DROP TYPE IF EXISTS getCalT CASCADE;


CREATE TABLE Users(
	uname 		varchar 	PRIMARY KEY,
	mass 		int,
	activity 	int,
	age 		int
);

CREATE TABLE Foods(
	fname 		varchar 	PRIMARY KEY,
	carbons 	float 		,
	fats 		float 		,
	proteins 	float 		,
	info 		varchar,
	isGround 	bool 		NOT NULL
)
;

CREATE TABLE IsPart(
	dname 		varchar 	,--REFERENCES Foods(fname) NOT NULL,
	fname  		varchar 	REFERENCES Foods(fname) NOT NULL,
	quantity	float 		NOT NULL,
	CONSTRAINT partTitle PRIMARY KEY (dname, fname)
)
;

CREATE TABLE Eaten(
	eid 		serial		PRIMARY KEY,
	uname		varchar 	REFERENCES Users(uname) NOT NULL,
	fname 		varchar 	REFERENCES Foods(fname) NOT NULL,
	quantity	float 		NOT NULL,
	dat 		timestamp 	DEFAULT current_timestamp
)
;

CREATE VIEW Eaten_cost AS
	SELECT eid, uname, fname, quantity, dat, carbons, fats, proteins 
	FROM
		Eaten
		JOIN Foods USING(fname)
;


/*////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
///			   Function Definitions
*/




/*Type for getCal function*/
CREATE TYPE getCalT AS(
	carbons int,
	fats 	int,
	proteins int
);

DROP FUNCTION IF EXISTS getUserEaten(varchar, interval);

CREATE OR REPLACE FUNCTION getUserEaten(varchar, interval) returns getCalT
AS $x$
DECLARE
	fats 	 int;
	carbons  int;
	proteins int;
	Vfats 	 int;
	Vcarbons  int;
	Vproteins int;
	quantity int;
BEGIN
	Vfats 	 =0;
	Vcarbons  =0;
	Vproteins =0;
	fats 	 =0;
	carbons  =0;
	proteins =0;
	quantity =0;
	FOR fats,carbons,proteins, quantity IN
		SELECT Eaten_cost.fats, Eaten_cost.carbons, Eaten_cost.proteins, Eaten_cost.quantity
		FROM 	Eaten_cost
		WHERE	uname = $1 
			AND dat >= current_timestamp - $2

	LOOP
		Vcarbons = Vcarbons + carbons * quantity;
		Vfats = Vfats + fats * quantity;
		Vproteins = Vproteins + proteins * quantity;
	END LOOP;
	RETURN (Vcarbons, Vfats, Vproteins);
END
$x$	LANGUAGE plpgsql
;


DROP FUNCTION IF EXISTS getCal(varchar)
;
--USAGE select carbons, fats, proteins FROM getCal('Spaghetti');
CREATE OR REPLACE FUNCTION getCal(varchar) returns getCalT
AS $x$
DECLARE
	fats int;
	carbons int;
	proteins int;
	calories int;
	quantity int;
BEGIN
	calories = 0;
	FOR fats,carbons,proteins, quantity IN
		SELECT Foods.fats, Foods.carbons, Foods.proteins, ispart.quantity
		FROM 	IsPart JOIN Foods ON (IsPart.fname = Foods.fname)
		WHERE	dname = $1
	LOOP
		calories = calories + (fats + carbons + proteins)*quantity;
	END LOOP;
	RETURN (calories,2,3);
END
$x$	LANGUAGE plpgsql
;


/*Trigger function for maitaining proper cfp for created disches*/
DROP FUNCTION IF EXISTS insertFoodsTriggerFunction()
;

CREATE OR REPLACE FUNCTION insertFoodsTriggerFunction() returns TRIGGER
AS $$
DECLARE
	fats 	 int;
	carbons  int;
	proteins int;
	Vfats 	 int;
	Vcarbons  int;
	Vproteins int;
	quantity int;
	isGround bool;
BEGIN
	Vfats 	 =0;
	Vcarbons  =0;
	Vproteins =0;
	fats 	 =0;
	carbons  =0;
	proteins =0;
	quantity =0;
	FOR fats,carbons,proteins, quantity IN
		SELECT Foods.fats, Foods.carbons, Foods.proteins, ispart.quantity
		FROM 	IsPart JOIN Foods ON (IsPart.fname = Foods.fname)
		WHERE	dname = NEW.fname
	LOOP
		Vcarbons = Vcarbons + carbons * quantity;
		Vfats = Vfats + fats * quantity;
		Vproteins = Vproteins + proteins * quantity;
	END LOOP;

	SELECT INTO isGround Foods.isGround FROM Foods WHERE fname = NEW.fname;

	IF isGround = false
	THEN
	UPDATE Foods
		SET carbons = Vcarbons,
		 	fats = Vfats,
		 	proteins = Vproteins
		WHERE fname = NEW.fname
	;
	END IF;

	RETURN NEW;
END
$$	LANGUAGE plpgsql
;

DROP TRIGGER IF EXISTS fillinFood ON Foods;

CREATE TRIGGER fillinFood
AFTER INSERT
ON Foods
FOR EACH ROW
EXECUTE PROCEDURE insertFoodsTriggerFunction()
;

--składniki wpisane na stałe
insert into Foods(fname, carbons, fats, proteins, info, isGround) VALUES
	('Pomidor', 12, 13, 14, 'Jaki dorodny!', true),
	('Makaron', 1, 2, 3, 'Jaki długi!', true),
	('Parmezan', 7, 3, 1, 'Jaki serowy!', true),
	('Marchew', 6, 3, 1, 'Jaka twarda!', true),
	('Seler', 3, 1, 3, 'Jakie to dziwne!', true)
;
	
insert into IsPart(dname, fname, quantity) VALUES
	('Spaghetti', 	'Pomidor', 5),
	('Spaghetti',	'Makaron', 2),
	('Spaghetti',	'Parmezan', 10),
	('Spaghetti',	'Marchew', 1),
	('Spaghetti',	'Seler', 1)
;

insert into Foods(fname,  info, isGround) VALUES
	('Spaghetti', 'Gorlami!', false)
;

insert into Users(uname, mass, activity, age) VALUES
	('Fatty', 105, 0, 22),
	('Slimmy', 55, 420, 22)
;

insert into Eaten(uname, fname, quantity, dat) VALUES
	('Fatty', 'Spaghetti', 5, DEFAULT),
	('Slimmy', 'Spaghetti', 2, '10-11-14')
;