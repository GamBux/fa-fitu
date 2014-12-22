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
	fname 		varchar 	UNIQUE NOT NULL,
	uid 		int 		references Users(uid),
	carbons 	int 		DEFAULT 0,
	fats 		int 		DEFAULT 0,
	proteins 	int 		DEFAULT 0,
	isGround 	bool 		NOT NULL,
	description text		DEFAULT 'Empty Description',
	recipe		text		DEFAULT 'To fully grow such a deliciuos...'
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

insert into Food(fname, carbons, fats, proteins, description, isGround) VALUES
	('Pomidor', 12, 13, 14, 'Jaki dorodny!', true),
	('Makaron', 1, 2, 3, 'Jaki długi!', true),
	('Parmezan', 7, 3, 1, 'Jaki serowy!', true),
	('Marchew', 6, 3, 1, 'Jaka twarda!', true),
	('Seler', 3, 1, 3, 'Jakie to dziwne!', true)
;
	
insert into Food(fname,  description, isGround) VALUES
	('Spaghetti', 'Gorlami!', false)
;

select InsertIsMadeOf('Spaghetti', 'Pamidor', 50);
select InsertIsMadeOf('Spaghetti', 'Makaron', 150);
select InsertIsMadeOf('Spaghetti', 'Parmezan', 20);
select InsertIsMadeOf('Spaghetti', 'Marchew', 120);
select InsertIsMadeOf('Spaghetti', 'Seler', 125);



/*insert into IsPart(dname, fname, quantity) VALUES
	('Spaghetti', 	'Pomidor', 5),
	('Spaghetti',	'Makaron', 2),
	('Spaghetti',	'Parmezan', 10),
	('Spaghetti',	'Marchew', 1),
	('Spaghetti',	'Seler', 1)
;



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

insert into Eaten(uid, fname, quantity, dat) VALUES
	(1, 'Spaghetti', 5, DEFAULT),
	(2, 'Spaghetti', 2, '10-11-14')
;

insert into Food(fname, uid, info, isGround) VALUES
('Sałatka', 1, 'mniam', false)
;

insert into IsPart(dname, fname, quantity) VALUES
('Sałatka','Marchew',1),
('Sałatka','Seler',2)
;
*/