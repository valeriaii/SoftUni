---1. One To One
CREATE DATABASE [TableRelations]

CREATE TABLE [Passports](
	[PassportID] INT PRIMARY KEY IDENTITY(101,1),
	[PassportNumber] VARCHAR(10) NOT NULL
)

CREATE TABLE [Persons](
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[Salary] DECIMAL(8,2) NOT NULL,
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL
)

INSERT INTO [Passports] ([PassportNumber])
	VALUES
		('N34FG21B')
		,('K65LO4R7')
		,('ZE657QP2')
INSERT INTO [Persons] ([FirstName],[Salary],[PassportID])
	VALUES
		('Roberto',43300.00,102)
		,('Tom',56100.00,103)
		,('Yana',60200.00,101)

---One to Many
CREATE TABLE [Manufacturers](
	[ManufacturerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL,
	[EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models](
	[ModelID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(30) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
)

INSERT INTO [Manufacturers]([Name],[EstablishedOn])
	VALUES
	('BMW', '1916-03-07'),
	('Tesla', '2003-01-01'),
	('Lada', '1966-05-01')

INSERT INTO [Models]([Name],[ManufacturerID])
	VALUES
	('X1', 1),
	('i6', 1),
	('ModelS', 2),
	('ModelX', 2),
	('Model3', 2),
	('Nova', 3)


----Many to Many

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(40) NOT NULL
)

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(80) NOT NULL
)
CREATE TABLE [StudentsExams](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]),
	PRIMARY KEY([StudentID],[ExamID])
)

INSERT INTO [Students] ([Name])
VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO [Exams] ([Name])
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO [StudentsExams] ([StudentID],[ExamID])
VALUES
	(1,101),
	(1,102),
	(2,101),
	(3,103),
	(2,102),
	(2,103)

------Self-Referencing
CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers] ([TeacherID]) 
)

INSERT INTO [Teachers] ([Name],[ManagerID])
VALUES
	('John',NULL),
	('Maya',106),
	('Silvia',106),
	('Ted',105),
	('Mark',101),
	('Greta',101)

--Problem 5.	Online Store Database

CREATE DATABASE [OnlineStore]

USE [OnlineStore]

CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY ,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY ,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE NOT NULL,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL
)

CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY ,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY ,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY ,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
)

CREATE TABLE [OrderItems](
	[OrderID] INT NOT NULL,
	[ItemID] INT NOT NULL,
	PRIMARY KEY([OrderID],[ItemID]),
	CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)
---Problem 6.	University Database

CREATE DATABASE [University]

USE [University]

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY,
	[StudentNumber] VARCHAR(15) NOT NULL,
	[StudentName] NVARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(7,2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)


CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY,
	[SubjectName] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Agenda](
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])

)
