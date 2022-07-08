--1.	Employee Address
SELECT TOP 5
e.[EmployeeID]
,e.[JobTitle]
,a.[AddressID]
,a.[AddressText]
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID ASC

--2.	Addresses with Towns
SELECT
e.FirstName
,e.LastName
,t.[Name] AS [Town]
,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID =a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY 
	e.FirstName,
	e.LastName 

--3.	Sales Employee

SELECT
e.EmployeeID
,e.FirstName
,e.LastName
,d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID =d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC

--4.	Employee Departments

SELECT TOP 5
e.EmployeeID
,e.FirstName
,e.Salary
,d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID =d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID ASC


--5.	Employees Without Project

SELECT TOP 3
e.EmployeeID
,e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--6.	Employees Hired After

SELECT 
e.FirstName
,e.LastName
,e.HireDate
,d.[Name] AS [DeptName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID =d.DepartmentID
WHERE e.HireDate > '1/1/1999'
AND d.[Name] = 'Sales' OR d.[Name] = 'Finance'	
ORDER BY e.HireDate ASC

--7.	Employees with Project

SELECT TOP 5
e.EmployeeID
,e.FirstName
,p.[Name] AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS  p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13 00:00:00.000'
AND p.EndDate IS NULL
ORDER BY e.EmployeeID  ASC

--8.	Employee 24

SELECT 
e.EmployeeID
,e.FirstName
,CASE 
	WHEN p.StartDate > '2005-01-01 00:00:00.000' THEN NULL
	ELSE p.[Name]
END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS  p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24


--9.	Employee Manager

SELECT 
e.EmployeeID
,e.FirstName
,m.EmployeeID AS [ManagerID]
,m.FirstName AS [ManagerName]
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE m.EmployeeID IN (3,7)
ORDER BY e.EmployeeID

--10. Employee Summary

SELECT TOP 50
e.EmployeeID
,CONCAT(e.FirstName,' ',e.LastName) AS [EmployeeName]
,CONCAT(m.FirstName,' ',m.LastName) AS [ManagerName]
,d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID=m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY EmployeeID

--11. Min Average Salary
SELECT min(avg_s) AS [MinAverageSalary]
FROM (
	SELECT  AVG(Salary) AS [avg_s]
	FROM Employees 
	GROUP BY DepartmentID
	) AS [AverageSalary]

--12. Highest Peaks in Bulgaria
GO
USE Geography
GO

SELECT 
c.CountryCode
,m.MountainRange
,p.PeakName
,p.Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries  AS c ON m.Id =c.MountainId
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges


SELECT 
c.CountryCode
,COUNT (mc.MountainId) AS [MountainRanges]
FROM Countries  AS c 
LEFT JOIN MountainsCountries AS mc ON c.CountryCode=mc.CountryCode
WHERE c.CountryCode IN ('BG','RU','US')
GROUP BY c.CountryCode

--14. Countries with Rivers

SELECT TOP 5
c.CountryName
,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId=r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15. *Continents and Currencies XXXX
SELECT 
	ContinentCode
	,CurrencyCode
	,CurrencyUsage
FROM(
		   SELECT *,
					DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage])
					AS [CurrencyRank]

			FROM (
				   SELECT
						 co.ContinentCode
						,c.CurrencyCode
						,COUNT(c.CurrencyCode) AS [CurrencyUsage]
					 FROM Continents AS co
				LEFT JOIN Countries AS c ON c.ContinentCode =co.ContinentCode
				GROUP BY co.ContinentCode,c.CurrencyCode
				) AS [CurrencyUsageQuery]
			WHERE CurrencyUsage  >1
	) AS [CurrencyRankingQuery]
	WHERE [CurrencyRank] = 1
	ORDER BY [ContinentCode]

----16. Countries Without Any Mountains
SELECT 
	COUNT(CountryCode) AS [Count]
FROM(
		SELECT 
		c.CountryCode,
		mc.MountainId
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		WHERE mc.MountainId IS NULL
		) AS [CountriesWithoutMountains]

--17. Highest Peak and Longest River by Country


SELECT TOP 5
		c.CountryName
		,MAX(p.Elevation) AS [HighestPeakElevation]
		,MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode=cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId=r.Id
LEFT JOIN MountainsCountries AS mc ON c.CountryCode=mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId=m.Id
LEFT JOIN Peaks AS p ON p.MountainId=m.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC
		,[LongestRiverLength] DESC
		,c.CountryName ASC
--18. Highest Peak Name and Elevation by Country