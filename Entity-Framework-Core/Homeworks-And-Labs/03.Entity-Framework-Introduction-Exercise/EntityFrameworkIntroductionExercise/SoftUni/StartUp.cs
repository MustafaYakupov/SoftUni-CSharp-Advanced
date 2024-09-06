using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        string result = RemoveTown(dbContext);

        Console.WriteLine(result);
    }

    // Problem 03
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .AsNoTracking()
            .ToArray(); // When reading without editing we must detach it from the change tracker

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }

        return sb.ToString().Trim();
    }

    // Problem 04
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeesWithSalaryOver50000 = context.Employees
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .Where(e => e.Salary > 50000)
            .ToArray();

        foreach (var e in employeesWithSalaryOver50000)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }

        return sb.ToString().Trim();
    }

    // Problem 05
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeesFromResearchAndDevelopment = context.Employees
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

        foreach (var e in employeesFromResearchAndDevelopment)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
        }

        return sb.ToString().Trim();
    }

    // Problem 06
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {

        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee? employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        employee!.Address = newAddress;

        context.SaveChanges();

        string[] employeeAddresses = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();

        return String.Join(Environment.NewLine, employeeAddresses);
    }

    // Problem 07
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeeWithProjects = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ?
                            ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished",
                    })
                    .ToArray()
            })
            .ToArray();

        foreach (var e in employeeWithProjects)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var project in e.Projects)
            {
                sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
            }
        }

        return sb.ToString().Trim();
    }

    // Problem 08
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var addressbyTown = context.Addresses
            .OrderByDescending(a => a.Employees.Count())
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town.Name,
                EmployeeCount = a.Employees.Count(),
            })
            .Take(10)
            .ToArray();

        foreach (var a in addressbyTown)
        {
            sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
        }
    
        return sb.ToString().Trim();
    }

    // Problem 09
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeeWithId147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .OrderBy(ep => ep.Project.Name)
                        .Select(ep => ep.Project.Name)
                        .ToArray(),
                })
                .ToArray();

        foreach (var e in employeeWithId147)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

            foreach (var ep in e.Projects)
            {
                sb.AppendLine(ep);
            }
        }

        return sb.ToString().Trim();
    }

    // Problem 10
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var departmentsWithMoreThan5Employees = context.Departments
            .Where(d => d.Employees.Count() > 5)
            .OrderBy(d => d.Employees.Count())
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Emloyees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        e.JobTitle,
                    })
                    .ToArray(),
            })
            .ToArray();

        foreach (var d in departmentsWithMoreThan5Employees)
        {
            sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

            foreach (var e in d.Emloyees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} = {e.JobTitle}");
            }
        }

        return sb.ToString().Trim();
    }

    // Problem 11
    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var latestProjects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate,
            })
            .ToArray();

        foreach (var p in latestProjects)
        {
            sb.AppendLine($"{p.Name}");
            sb.AppendLine($"{p.Description}");
            sb.AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
        }

        return sb.ToString().Trim();
    }

    // Problem 12
    public static string IncreaseSalaries(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeesToPromote = context
            .Employees
            .Where(e =>
                e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                Salary = e.Salary * 1.12m,
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName);

        foreach (var e in employeesToPromote)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
        }

        context.SaveChanges();

        return sb.ToString().Trim();
    }

    // problem 13
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeesStartingWith = context
            .Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary,
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        foreach (var e in employeesStartingWith)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }

        return sb.ToString().Trim();
    }

    // Problem 14
    public static string DeleteProjectById(SoftUniContext context)
    {
        IQueryable<EmployeeProject> employeeProjectsToDelete = context.EmployeesProjects
            .Where(ep => ep.ProjectId == 2);

        context.EmployeesProjects.RemoveRange(employeeProjectsToDelete);

        Project projectToDelete = context.Projects.Find(2)!;
        context.Projects.Remove(projectToDelete);

        context.SaveChanges();

        string[] projectNames = context
            .Projects
            .Take(10)
            .Select(p => p.Name)
            .ToArray();

        return String.Join(Environment.NewLine, projectNames);
    }

    // Problem 15
    public static string RemoveTown(SoftUniContext context)
    {
        var townToDelete = context
               .Towns
               .First(t => t.Name == "Seattle");

        IQueryable<Address> addressesToDelete =
            context
                .Addresses
                .Where(a => a.TownId == townToDelete.TownId);

        int addressesCount = addressesToDelete.Count();

        IQueryable<Employee> employeesOnDeletedAddresses =
            context
                .Employees
                .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

        foreach (var employee in employeesOnDeletedAddresses)
        {
            employee.AddressId = null;
        }

        foreach (var address in addressesToDelete)
        {
            context.Addresses.Remove(address);
        }

        context.Remove(townToDelete);

        context.SaveChanges();

        return $"{addressesCount} addresses in Seattle were deleted";
    }
}