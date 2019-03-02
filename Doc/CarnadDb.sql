-- Date: Feb 2019
-- Author: X. Carrel
-- Goal: Creates the Carnad DB as ASP course material

USE master
GO

-- First delete the database if it exists
IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Carnad'))
BEGIN
	USE master
	ALTER DATABASE Carnad SET SINGLE_USER WITH ROLLBACK IMMEDIATE; -- Disconnect users the hard way (we cannot drop the db if someone's connected)
	DROP DATABASE Carnad -- Destroy it
END
GO

-- Second ensure we have the proper directory structure
SET NOCOUNT ON;
GO
CREATE TABLE #ResultSet (Directory varchar(200)) -- Temporary table (name starts with #) -> will be automatically destroyed at the end of the session

INSERT INTO #ResultSet EXEC master.sys.xp_subdirs 'c:\' -- Stored procedure that lists subdirectories

IF NOT EXISTS (Select * FROM #ResultSet where Directory = 'DATA')
	EXEC master.sys.xp_create_subdir 'C:\DATA\' -- create DATA

DELETE FROM #ResultSet -- start over for MSSQL subdir
INSERT INTO #ResultSet EXEC master.sys.xp_subdirs 'c:\DATA'

IF NOT EXISTS (Select * FROM #ResultSet where Directory = 'MSSQL')
	EXEC master.sys.xp_create_subdir 'C:\DATA\MSSQL'

DROP TABLE #ResultSet -- Explicitely delete it because the script may be executed multiple times during the same session
GO

-- Everything is ready, we can create the db
CREATE DATABASE Carnad ON  PRIMARY 
( NAME = 'Carnad_data', FILENAME = 'C:\DATA\MSSQL\Carnad.mdf' , SIZE = 20480KB , MAXSIZE = 51200KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = 'Carnad_log', FILENAME = 'C:\DATA\MSSQL\Carnad.ldf' , SIZE = 10240KB , MAXSIZE = 20480KB , FILEGROWTH = 1024KB )

GO

-- Create tables 

USE Carnad
GO

CREATE TABLE Groups(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name varchar(15) UNIQUE NOT NULL,
	Description varchar(500))

CREATE TABLE Countries(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Dialcode int,
	Name varchar(15) UNIQUE NOT NULL)

CREATE TABLE Contacts(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	PhoneNumber varchar(15),
	Email varchar(250),
	Country_id int NOT NULL)
CREATE UNIQUE NONCLUSTERED INDEX UniqueContact ON Contacts (FirstName,LastName)

CREATE TABLE Belong (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Contact_id int,
	Group_id int)
	
ALTER TABLE Contacts WITH CHECK ADD  CONSTRAINT FK_Customer_Country FOREIGN KEY(Country_id)
REFERENCES Countries(id)

ALTER TABLE Belong WITH CHECK ADD  CONSTRAINT FK_Belong_Contact FOREIGN KEY(Contact_id)
REFERENCES Contacts(id)

ALTER TABLE Belong WITH CHECK ADD  CONSTRAINT FK_Belong_Group FOREIGN KEY(Group_id)
REFERENCES Groups(id)

GO

-- Insert data

INSERT INTO Groups(Name) VALUES ('Travail'),('Amis'),('Famille'),('Tennis')

INSERT INTO Countries(DialCode,Name) VALUES (41,'Suisse'),(33,'France'),(49,'Allemagne'),(39,'Italie')

INSERT INTO Contacts(FirstName, LastName, PhoneNumber, Email, Country_id) VALUES
	('Marcello','Fonte','123 33 22',null,4),
	('Viktor','Polster',null,null,3),
	('Bruno','Ganz','332 32 23','bruno@paradise.org',1),
	('Isabelle','Adjani',null,null,2),
	('Jean-Pierre','Aumont','111 254 522','jp@gmail.com',2),
	('Yvette','Chauviré','987 454 332','yvette@yahoo.fr',2),
	('Vincent','Perez',null,null,1),
	('James','Gandolfini','3211 2331 12',null,1);

INSERT INTO Belong (Contact_id, Group_id) VALUES
	(1,1),
	(1,2),
	(2,3),
	(2,4),
	(4,2),
	(5,4),
	(5,1),
	(6,1),
	(7,1),
	(7,1),
	(7,2),
	(7,4);

SET NOCOUNT OFF;
GO
