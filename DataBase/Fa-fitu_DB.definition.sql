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
DROP TABLE IF EXISTS Food CASCADE;
DROP TABLE IF EXISTS IsPart CASCADE;
DROP TABLE IF EXISTS IsMadeOf CASCADE;
DROP TABLE IF EXISTS Eaten CASCADE;
DROP TYPE IF EXISTS getCalT CASCADE;


CREATE TABLE Users(
	uid 		serial PRIMARY KEY,
	uname 		varchar NOT NULL,
	email		varchar UNIQUE,
	pass		varchar,
	mass 		int,
	activity 	int,
	age 		int,
	caloriesTarget int,
	service int NOT NULL DEFAULT 0,
	UNIQUE 	(service,uname)
);

CREATE TABLE Food(
	fid 		serial		PRIMARY KEY,	
	fname 		varchar 	NOT NULL,
	uid 		int 		references Users(uid),
	carbons 	int 		DEFAULT 0,
	fats 		int 		DEFAULT 0,
	proteins 	int 		DEFAULT 0,
	isGround 	bool 		DEFAULT true NOT NULL,
	description text		DEFAULT 'Empty Description',
	recipe		text		DEFAULT 'To fully grow such a deliciuos...',
	weightSoFar	int 		DEFAULT 0,
	UNIQUE (fname, uid)
)
;

CREATE TABLE IsMadeOf(
	dfid	int REFERENCES Food(fid),
	ffid 	int REFERENCES Food(fid),
	weight int
);

CREATE TABLE Eaten(
	eid 		serial		PRIMARY KEY,
	uid			int 		REFERENCES Users(uid) NOT NULL,
	fid 		int 		REFERENCES Food(fid) NOT NULL,
	quantity	float 		NOT NULL,
	dat 		timestamp 	DEFAULT current_timestamp
)
;


CREATE OR REPLACE FUNCTION InsertIsMadeOf(varchar, varchar, int) returns int
AS $x$
DECLARE
	Affid int;
	Adfid int;
BEGIN
	SELECT INTO Adfid Food.fid FROM Food WHERE Food.fname = $1;
	SELECT INTO Affid Food.fid FROM Food WHERE Food.fname = $2;
	INSERT INTO IsMadeOf(dfid, ffid, weight) VALUES (Adfid, Affid, $3);
	RETURN 0;
END
$x$	LANGUAGE plpgsql
;


DROP TRIGGER IF EXISTS T_Update_Food_Calories_Ins_IsMadeOf ON IsMadeOf;

CREATE OR REPLACE FUNCTION TF_Update_Food_Calories_Ins_IsMadeOf() RETURNS TRIGGER
AS $x$
DECLARE
	upFood Food;
	upPart Food;
	newCarbon int;
	newProtein int;
	newFat int;
	newWeight int;
BEGIN
	SELECT INTO upFood Food.* FROM Food WHERE Food.fid = NEW.dfid;
	SELECT INTO upPart Food.* FROM Food WHERE Food.fid = NEW.ffid;
	newWeight 	=	upFood.weightSoFar + NEW.weight; 
	newFat 		=	(upFood.fats 	* upFood.weightSoFar + upPart.fats		* NEW.weight )	/ newWeight; 
	newProtein 	= 	(upFood.proteins* upFood.weightSoFar + upPart.proteins 	* NEW.weight )	/ newWeight;
	newCarbon 	= 	(upFood.carbons * upFood.weightSoFar + upPart.carbons 	* NEW.weight )	/ newWeight;
	UPDATE Food 
		SET (carbons,fats,proteins,weightSoFar) = (newCarbon, newFat, newProtein, newWeight)
		WHERE fid = NEW.dfid
	;
	RETURN NEW;
END
$x$	LANGUAGE plpgsql
;

CREATE TRIGGER T_Update_Food_Calories_Ins_IsMadeOf
AFTER INSERT
ON IsMadeOf
FOR EACH ROW
EXECUTE PROCEDURE TF_Update_Food_Calories_Ins_IsMadeOf()
;

insert into Food(fname, proteins, carbons, fats, description, isGround) VALUES
	('Pomidor', 14, 2, 4, 'Jaki dorodny!', true),
	('Makaron', 13*4, 69*4, 2*9, 'Jaki długi!', true),
	('Parmezan', 33*4, 0*4, 28*9, 'Jaki serowy!', true),
	('Marchew', 1*4, 5*4, 1*9, 'Jaka twarda!', true),
	('Seler', 2*4, 8*4, 1*9, 'Jakie to dziwne!', true),
	('Mięcho', 17*4, 8*4, 22*9, 'Mięsne', true)

;
	
insert into Food(fname,  description, isGround) VALUES
	('Spaghetti', 'Gorlami!', false)
;

select InsertIsMadeOf('Spaghetti', 'Pomidor', 200);
select InsertIsMadeOf('Spaghetti', 'Makaron', 150);
select InsertIsMadeOf('Spaghetti', 'Parmezan', 20);
select InsertIsMadeOf('Spaghetti', 'Marchew', 120);
select InsertIsMadeOf('Spaghetti', 'Seler', 125);
select InsertIsMadeOf('Spaghetti', 'Mięcho', 225);


insert into Users(uname, email, pass, mass, activity, age, caloriesTarget) VALUES
	('Fatty','bladbla@bal.bla', 'A', 105, 0, 22, 2500),
	('Slimmy','blabla@bal.bla', 'AA', 55, 420, 22, 1800)
;

insert into Users(uname, email, pass, activity, age, caloriesTarget) VALUES
	('Antigravity','I have no weight', 'A', 0, 22, 2500)
;

insert into Users(uname, pass, mass, activity, age, caloriesTarget) VALUES
	('Webless','I have no email', 50, 0, 22, 2500)
;
