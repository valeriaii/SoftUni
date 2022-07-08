USE [Gringotts]

GO
SELECT *
FROM [WizzardDeposits]

--1. Records’ Count

SELECT COUNT(Id) AS [Count]
FROM [WizzardDeposits]


--2. Longest Magic Wand

SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]

--3. Longest Magic Wand Per Deposit Groups

   SELECT 
		  [DepositGroup], 
		  MAX([MagicWandSize]) AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--4. * Smallest Deposit Group Per Magic Wand Size

SELECT TOP 2
		[DepositGroup]
FROM(
	SELECT
		 [DepositGroup], 
		 AVG([MagicWandSize]) AS [AverageSize]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]
)     AS [AverageWandSize]
ORDER BY [AverageSize] ASC


--5. Deposits Sum

	SELECT
		 [DepositGroup], 
		 SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--6. Deposits Sum for Ollivander Family

	SELECT
		 [DepositGroup], 
		 SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

--7. Deposits Filter

	SELECT
		 [DepositGroup], 
		 SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount])<150000
ORDER BY [TotalSum] DESC

--8.  Deposit Charge

   SELECT 
		 [DepositGroup]
		,[MagicWandCreator]
		,MIN([DepositCharge])
    FROM [WizzardDeposits]
GROUP BY [DepositGroup],[MagicWandCreator]
ORDER BY [MagicWandCreator],[DepositGroup]

		

--9. Age Groups

SELECT 
		[AgeGroup]
		,COUNT(*) AS [WizzardCount]
FROM(
		SELECT [Age],
				CASE
					WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
					WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
					WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
					WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
					WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
					WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
					WHEN [Age] >= 61 THEN '[61+]'
				END
			 AS [AgeGroup]
		FROM [WizzardDeposits]
	) AS [AgeGroupSubquery]
GROUP BY [AgeGroup]

--10. First Letter
SELECT *
FROM(
	SELECT LEFT([FirstName],1) AS [FirstLetter]
	FROM [WizzardDeposits]
	WHERE [DepositGroup] = 'Troll Chest'
	) AS [FirstLetterQuery]
GROUP BY [FirstLetter]
ORDER BY [FirstLetter]

--11. Average Interest 

		   SELECT 
			     [DepositGroup]
			    ,[IsDepositExpired]
		       	,AVG([DepositInterest]) AS [AverageInterest]
		    FROM [WizzardDeposits]
		   WHERE [DepositStartDate]>'01/01/1985'
		GROUP BY [DepositGroup],[IsDepositExpired]
		ORDER BY [DepositGroup] DESC,
				 [IsDepositExpired] ASC


--12. * Rich Wizard, Poor Wizard

SELECT 
*
FROM [WizzardDeposits] AS wd1
JOIN [WizzardDeposits] AS wd2 ON wd1.Id +1 = wd2.Id


SELECT SUM([HostWizzardDeposit]-[GuestWizzardDeposit])
	AS [SumDifference]
 FROM(
		SELECT 	[FirstName] AS [HotWizzard]
			   ,[DepositAmount] AS [HostWizzardDeposit]
			   , LEAD([FirstName]) OVER(ORDER BY [Id]) 
		    AS [GuestWizzard]
			   ,LEAD([DepositAmount]) OVER(ORDER BY [Id]) 
		    AS [GuestWizzardDeposit]
		  FROM [WizzardDeposits] 
	 ) AS [Subquery]

--13. Departments Total Salaries
GO
USE SoftUni
GO

SELECT [DepartmentID],SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--14. Employees Minimum Salaries

SELECT [DepartmentID],MIN([Salary]) AS [MinimumSalary]
FROM [Employees]
WHERE [DepartmentID] IN (2,5,7) AND [HireDate] > '01/01/2000'
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]


--15. Employees Average Salaries

SELECT * INTO [EmployeesAS] FROM Employees
WHERE [Salary] > 30000
 
DELETE FROM EmployeesAS
WHERE [ManagerID] = 42
 
UPDATE EmployeesAS
SET [Salary] += 5000
WHERE [DepartmentID] = 1
 
SELECT [DepartmentID],
    AVG([Salary]) as [AverageSalary]
FROM EmployeesAS
GROUP BY [DepartmentID]

--16. Employees Maximum Salaries

SELECT [DepartmentID],MAX([Salary]) AS [MaxSalary]
FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) <30000 OR MAX([Salary])>70000



--17. Employees Count Salaries

SELECT COUNT([Salary]) AS [Count]
FROM [Employees]
WHERE [ManagerID] IS NULL



--18. *3rd Highest Salary

 
SELECT DISTINCT [DepartmentId], [Salary] AS ThirdHighestSalary
FROM 
(
SELECT  [DepartmentId], [Salary],
DENSE_RANK() OVER (PARTITION BY [DepartmentId] ORDER BY [Salary] DESC ) RANK_SALARY
FROM Employees
) AS [Ranked]
	
WHERE RANK_SALARY = 3;

--19. **Salary Challenge


SELECT TOP 10
			[FirstName]
			,[LastName]
			,[DepartmentID]

		FROM [Employees] AS e
	   WHERE [Salary]> ( 
					SELECT 
						 AVG(Salary) AS [AvgSalary]
					FROM [Employees] AS esub
					WHERE esub.[DepartmentID] = e.[DepartmentID]
				GROUP BY [DepartmentID]
				)
	ORDER BY [DepartmentID]


