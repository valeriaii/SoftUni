using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var context = new SoftUniContext();

            ////Problem 3
            //string allEmployees = GetEmployeesFullInformation(context);

            //Console.Write(allEmployees);

            ////Problem 4
            //string employeesSalaryOver50000 = GetEmployeesWithSalaryOver50000(context);
            //Console.Write(employeesSalaryOver50000);

            ////Problem 5
            //string rndEmployees = GetEmployeesFromResearchAndDevelopment(context);
            //Console.Write(rndEmployees);

            ////Problem 8
            //string addresses = GetAddressesByTown(context);
            //Console.Write(addresses);

            ////Problem 9
            //string addresses = GetEmployee147(context);
            //Console.Write(addresses);

            ////Problem 10
            //string departments = GetDepartmentsWithMoreThan5Employees(context);
            //Console.Write(departments);


            //Problem 11
            string projects = GetLatestProjects(context);
            Console.Write(projects);

            ////Problem 12
            //string updatedSalaries = IncreaseSalaries(context);
            //Console.Write(updatedSalaries);


            ////Problem 13
            //string employees = GetEmployeesByFirstNameStartingWithSa(context);
            //Console.Write(employees);

            ////Problem 14
            //string projects = DeleteProjectById(context);
            //Console.Write(projects);

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();
            
            var allEmployees = context
                .Employees //DbSet<Employee>
                 .OrderBy(e => e.EmployeeId) //IOrderedEnumerable<Employee>
                 .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     e.MiddleName,
                     e.JobTitle,
                     e.Salary
                 })
                 .ToArray(); //Employee[]

            foreach (var e in allEmployees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }


            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var allEmployees = context.Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray()
                .Where(e=>e.Salary>50000);

            foreach (var employee in allEmployees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }


            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var rndEmployees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            foreach (var employee in rndEmployees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - {employee.Salary:f2}");
            }
            return result.ToString().TrimEnd();
        }

       
        public static string AddNewAddressToEmployee(SoftUniContext context) 
        {

            StringBuilder result = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee nakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            nakov.Address = newAddress;
           context.SaveChangesAsync();

            string[] addressText = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();

            foreach (string address in addressText)
            {
                result.AppendLine(address);
            }
            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context) 
        {
            StringBuilder result = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects
                                .Select(ep => new { 
                                        ProjectName = ep.Project.Name,
                                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                                        EndDate = ep.Project.EndDate.HasValue?ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"):"not finished"

                                }).ToArray()
                })
                .ToArray();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var p in employee.AllProjects)
                {
                    result.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }


            return result.ToString().TrimEnd();
        }
        //not working
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a=> new
                {
                    a.AddressText,
                    TownName= a.Town.Name,
                    EmployeeCount =         a.Employees.Count()
                })
                .Take(10)
                .ToArray();

            foreach (var a in addresses)
            {
                result.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }


            return result.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employee147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    AllProjects = e.EmployeesProjects
                        .OrderBy(ep => ep.Project.Name)
                        .Select(ep => new { ProjectName = ep.Project.Name })
                        .ToArray()

                })
                .ToArray();

            result.AppendLine($"{employee147[0].FirstName} {employee147[0].LastName} - {employee147[0].JobTitle}");

            foreach (var project in employee147[0].AllProjects)
            {
                result.AppendLine($"{project.ProjectName}");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    AllEmployees = d.Employees
                                    .OrderBy(e=>e.FirstName)
                                    .ThenBy(e=>e.LastName)
                                    .Select(e => new
                                    {
                                        e.FirstName,
                                        e.LastName,
                                        e.JobTitle
                                    })
                                    .ToArray()
                })
                .ToArray();

            foreach (var d in departments)
            {
                result.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");
                foreach (var e in d.AllEmployees)
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var projects = context.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .Select(p => new
                    {
                        p.Name,
                        p.Description,
                        p.StartDate
                    })

                    .OrderBy(p => p.Name)
                    .ToArray();

            foreach (var p in projects)
            {
                result.AppendLine(p.Name);
                result.AppendLine(p.Description);
                result.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt" + "AM"));
            }

            return result.ToString().TrimEnd();




        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();
            var employeesToUpdate = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                 || e.Department.Name == "Tool Design"
                 || e.Department.Name == "Marketing"
                 || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)             
                .ToArray();
            foreach (var employee in employeesToUpdate)
            {
                employee.Salary *= 1.12m;
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})"); 

            }
            context.SaveChanges();
            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

       
            var employees = context.Employees
                .Where(e => (e.FirstName.ToLower().StartsWith("sa")))
                .OrderBy(e=>e.FirstName)
                .ThenBy(e=>e.LastName)
                .Select(e => new
                 {
                     e.FirstName,
                     e.LastName,
                     e.JobTitle,
                     e.Salary
                 })
                .ToList();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return result.ToString().TrimEnd();

        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();
            Project projectToDelete = context.Projects.Find(2);

            EmployeeProject[] referredEmployees = context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectToDelete.ProjectId)
                .ToArray();

            context.EmployeesProjects.RemoveRange(referredEmployees);
            context.Projects.Remove(projectToDelete);

            string[] projectNames = context.Projects

                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            foreach (string pName in projectNames)
            {
                result.AppendLine(pName);
            }

            return result.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Town townToDelete = context
                 .Towns
                 .First(t => t.Name == "Seattle");

            Address[] addressesToDelete =
                context
                    .Addresses
                    .Where(a => a.TownId == townToDelete.TownId)
                    .ToArray();

            Employee[] employeesToUpdate = context.Employees
                .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (var e in employeesToUpdate)
            {
                e.AddressId = null;
            }
            
            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            return $"{addressesToDelete.Count()} addresses in Seattle were deleted";
        }
    }
}
