GO
USE SoftUni
GO

--1.	Employees with Salary Above 35000
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS 
BEGIN
	SELECT [FirstName],[LastName]
	FROM [Employees]
	WHERE [Salary] > 35000
END

GO

EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]
--2.	Employees with Salary Above Number

GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber  @MinSalary DECIMAL(18,4)
AS 
BEGIN
	SELECT [FirstName],[LastName]
	FROM [Employees]
	WHERE [Salary] >= @MinSalary
END

GO

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] @MinSalary = 10022

--3.	Town Names Starting With
GO
CREATE PROCEDURE usp_GetTownsStartingWith @StartString VARCHAR(10)
AS
BEGIN 
		SELECT [Name]
		FROM [Towns]
		WHERE [Name] LIKE  @StartString+'%'
END
GO

EXEC [dbo].usp_GetTownsStartingWith @StartString = 'b'
--4.	Employees from Town


GO

CREATE	PROCEDURE usp_GetEmployeesFromTown @TownName VARCHAR(30)
AS
BEGIN
	SELECT [FirstName], [LastName]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON e.AddressID = a.AddressID
	JOIN [Towns] AS t ON a.TownID =t.TownID
	WHERE t.[Name]=@TownName
END

GO

EXEC usp_GetEmployeesFromTown @TownName = 'Berlin'


--5.	Salary Level Function
GO

CREATE FUNCTION ufn_GetSalaryLevel (@Salary DECIMAL(18,4)) 
RETURNs VARCHAR(8)
AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(8)
	SET @SalaryLevel = 'Low'
	
	IF @Salary BETWEEN 30000 AND 50000
		BEGIN
			SET @SalaryLevel = 'Average'
		END
	IF @Salary >50000
		BEGIN
			SET @SalaryLevel = 'High'
		END
	RETURN @SalaryLevel
END

GO

SELECT [Salary]
		,dbo.ufn_GetSalaryLevel([Salary]) AS [Salary Level]
FROM [Employees]

--6.	Employees by Salary Level

GO

CREATE	PROCEDURE usp_EmployeesBySalaryLevel  @SalaryLevel VARCHAR(8)
AS
BEGIN
	
	SELECT [FirstName], [LastName]
	FROM [Employees] 
	WHERE dbo.ufn_GetSalaryLevel([Salary]) = @SalaryLevel
END

GO

EXEC dbo.usp_EmployeesBySalaryLevel @SalaryLevel = 'Low'

--7.	Define Function
GO
CREATE FUNCTION ufn_IsWordComprised
  (
  @setOfLetters nvarchar(255), 
  @word nvarchar(255)
  )
RETURNS bit
AS
BEGIN 
    DECLARE @l int = 1;
    DECLARE @exist bit = 1;
    WHILE LEN(@word) >= @l AND @exist > 0
    BEGIN
      DECLARE @charindex int; 
      DECLARE @letter char(1);
      SET @letter = SUBSTRING(@word, @l, 1)
      SET @charindex = CHARINDEX(@letter, @setOfLetters, 0)
      SET @exist =
        CASE
            WHEN  @charindex > 0 THEN 1
            ELSE 0
        END;
      SET @l += 1;
    END

    RETURN @exist
END
GO


--8.	* Delete Employees and Departments



--9.	Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
         SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] 
         FROM AccountHolders
END


--10.	People with Balance Higher Than



--11.	Future Value Function



--12.	Calculating Interest



--13.	*Scalar Function: Cash in User Games Odd Rows