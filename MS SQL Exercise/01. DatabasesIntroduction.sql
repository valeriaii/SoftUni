--Ex. 1
CREATE DATABASE [Minions]
GO

USE [Minions]

GO

CREATE TABLE [Minions](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] TINYINT NOT NULL
)

CREATE TABLE [Towns] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(70) NOT NULL,
)

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

ALTER TABLE [Minions]
ALTER COLUMN [Age] INT

INSERT INTO [Towns]( [Name])
	VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna')




INSERT INTO [Minions] ([Name],[Age],[TownId])
	VALUES 
		('Kevin',22,1),
		('Bob',15,3),
		('Steward',NULL,2)

SELECT * FROM [Towns]
SELECT * FROM [Minions]
GO
TRUNCATE TABLE [Minions]

GO

CREATE TABLE [People](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH ([Picture])<= 2000000),
	[Height] DECIMAL (3,2),
	[Weight] DECIMAL (5,2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender]='m' OR [Gender]='f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)	
)

INSERT INTO [People] ([Name],[Height],[Weight],[Gender],[Birthdate])
	VALUES
		('Mimi',1.62,44.5,'f','2003-04-05'),
		('Mitko',1.88,77.5,'m','1995-08-05'),
		('Viki',NULL,48.5,'f','2000-11-05'),
		('Viktor',1.92,80.5,'m','1998-07-22'),
		('Petko',1.72,NULL,'m','2002-06-05')

CREATE TABLE [Users](
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH ([ProfilePicture])<= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] VARCHAR(5) NOT NULL,
	CHECK ([IsDeleted]='true' OR [IsDeleted]='false'),
		
)
INSERT INTO [Users] ([Username],[Password],[LastLoginTime],[IsDeleted])
	VALUES
		('Mimi','kfhdghi','2003-04-05','false'),
		('kikito','jfheu','2018-08-05','true'),
		('super_mario','58dfu','2022-04-05','false'),
		('viki.78','jrur8','2000-12-05','true'),
		('mitaka','mitko22','2022-03-22','false')

--change primary key
ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC078A90F60E

ALTER TABLE [Users]
ADD PRIMARY KEY([Id],[Username])

--add check constraint
ALTER TABLE [Users]
ADD CHECK (DATALENGTH ([Password])>=5)

--set default value to a field
ALTER TABLE [Users]
ADD CONSTRAINT DF_LastLoginTime DEFAULT (SYSDATETIME()) FOR [LastLoginTime]

--set unique field
ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__77222459EFB51E29

ALTER TABLE [Users]
ADD PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CHECK (DATALENGTH ([Username])>=3)

--Movies database
CREATE DATABASE [Movies]

CREATE TABLE [Directors] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(max)
)
CREATE TABLE [Genres] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(max)
)
CREATE TABLE [Categories] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(max)
)
CREATE TABLE [Movies] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Title] NVARCHAR(80) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] DATE NOT NULL ,
	[Length] SMALLINT NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres] ([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories] ([Id])  NOT NULL,
	[Rating] SMALLINT ,
	[Notes] NVARCHAR(max)
)

INSERT INTO [Directors] ([DirectorName])
	VALUES
		('John Lock'),
		('Sarah Peterson'),
		('Jack Clark'),
		('Laura Baily'),
		('Travis')
INSERT INTO [Genres] ([GenreName])
	VALUES
		('Adventure'),
		('Romance'),
		('Drama'),
		('Animation'),
		('Horror')

INSERT INTO [Categories] ([CategoryName])
	VALUES
		('Kids'),
		('Family'),
		('Adult'),
		('Baby'),
		('Series')

INSERT INTO [Movies] ([Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId])
	VALUES
	('Swan Princess',2,'1990-12-01',125,2,1),
	('Circle',3,'1990-12-01',150,3,2),
	('Hulk',1,'2000-12-01',150,2,1),
	('Monsters', 3,'1980-12-01',80,3,2),
	('Princess',2,'1990-12-01',70,3,2)

SELECT * FROM [Movies]

--softuni database

CREATE DATABASE [SoftUni]

CREATE TABLE [Towns] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(30) NOT NULL
)
CREATE TABLE [Addresses] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[AddressText] NVARCHAR(80) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
)
CREATE TABLE [Departments] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(30) NOT NULL
)
CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(30) NOT NULL,
	[MiddleName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[JobTitle] NVARCHAR(30) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]),
	[HireDate] DATE NOT NULL,
	[Salary] DECIMAL(6,2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)

INSERT INTO [Towns] ([Name])
VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')
INSERT INTO [Departments] ([Name])
VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

INSERT INTO [Employees] ([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary])
VALUES
	('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00),
	('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00),
	('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
	('Georgi','Terziev','Ivanov','CEO',2,'2007-12-09',3000.00),
	('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88)

SELECT [Name] FROM [Towns]
ORDER BY [Name] ASC

SELECT [Name] FROM [Departments]
ORDER BY [Name] ASC

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees]
ORDER BY [Salary] DESC

UPDATE [Employees]
SET [Salary] = [Salary] * 1.10
SELECT  [Salary] FROM [Employees]
ORDER BY [Salary] DESC


