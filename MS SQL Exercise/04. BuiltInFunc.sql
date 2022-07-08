USE [SoftUni]

GO
--Problem 1.	Find Names of All Employees by First Name
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

 SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE  LEFT([FirstName],2)='Sa'

 --Problem 2.	Find Names of All employees by Last Name 
SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

 --Problem 3.	Find First Names of All Employees

 SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3,10) AND DATEPART(YEAR,[HireDate]) BETWEEN 1995 AND 2005 

 --Problem 4.	Find All Employees Except Engineers

 SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'

 --Problem 5.	Find Towns with Name Length
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5,6)
 ORDER BY [Name] ASC

 --Problem 6.	Find Towns Starting With
   SELECT *
    FROM [Towns]
   WHERE LEFT([Name],1) IN ('M', 'K','B','E')
 ORDER BY [Name] ASC

 --Problem 6.	Find Towns Starting With
    SELECT *
    FROM [Towns]
   WHERE LEFT([Name],1) NOT IN ('R','B','D')
 ORDER BY [Name] ASC

 --Problem 8.	Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
 SELECT [FirstName], [LastName]
  FROM [Employees]
  WHERE DATEPART(YEAR,[HireDate]) > 2000 

  --Problem 9.	Length of Last Name
  SELECT [FirstName], [LastName]
  FROM [Employees]
  WHERE LEN([LastName])=5

--Problem 10.	 Rank Employees by Salary
  SELECT [EmployeeID],[FirstName], [LastName],[Salary],
		DENSE_RANK() OVER ( PARTITION  BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000 
ORDER BY [Salary] DESC

--Problem 11.	Find All Employees with Rank 2 *
  SELECT *
  FROM(
	SELECT [EmployeeID],[FirstName], [LastName],[Salary],
		DENSE_RANK() OVER ( PARTITION  BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
      FROM [Employees]
     WHERE [Salary] BETWEEN 10000 AND 50000 

  )
  AS [RankingSubquery]
  WHERE [RANK]=2
  ORDER BY [Salary] DESC

  --Problem 12.	Countries Holding 'A' 3 or More Times
  GO
  
  USE [Geography]

  GO

  SELECT [CountryName], [IsoCode]
    FROM [Countries]
   WHERE LOWER([CountryName]) LIKE '%a%a%a%'
   ORDER BY [IsoCode] ASC

  --Problem 13.	 Mix of Peak and River Names
  SELECT [Peaks].[PeakName],[Rivers].[RiverName],
		LOWER(CONCAT(LEFT([Peaks].[PeakName],LEN([Peaks].[PeakName])-1),[Rivers].[RiverName]))
		AS [Mix]
    FROM [Rivers],[Peaks]
   WHERE RIGHT([Peaks].[PeakName],1) = LEFT([Rivers].[RiverName],1)
   ORDER BY [Mix] ASC

--Problem 14.	Games from 2011 and 2012 year
GO

USE [Diablo]

GO

  SELECT TOP(50) [Name],FORMAT([Start],'yyyy-MM-dd') AS [Start]
    FROM [Games] 
   WHERE DATEPART(YEAR,[Start]) IN (2011,2012)
ORDER BY [Start] ASC,
         [Name]  ASC

--Problem 15.	 User Email Providers
SELECT [Username], 
		SUBSTRING([Email],CHARINDEX('@',[Email])+1,LEN([Email]))
		AS [Email Provider]
  FROM [Users]
ORDER BY [Email Provider] ASC,
		 [Username] ASC

--Problem 16.	 Get Users with IPAdress Like Pattern


--Problem 17.	 Show All Games with Duration and Part of the Day
SELECT 
  FROM [Games]