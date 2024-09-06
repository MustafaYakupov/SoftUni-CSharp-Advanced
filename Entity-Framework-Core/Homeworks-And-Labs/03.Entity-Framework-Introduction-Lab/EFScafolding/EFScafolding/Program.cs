using EFScafolding.Data;
using EFScafolding.Models;
using Microsoft.EntityFrameworkCore;

using (SoftUniContext context = new SoftUniContext())
{
    DateTime oldEmployeeDate = new DateTime(2000, 1, 1);
    List<Employee> employees = await context.Employees
        .Where(e => e.HireDate < oldEmployeeDate)
        .ToListAsync();

    foreach (var employee in employees)
    {
        Console.WriteLine($"{employee.FirstName} {employee.LastName}");
    }

    var person = await context.Employees.FindAsync(30);

    Console.WriteLine($"{person.FirstName} {person.LastName}");

    // Select more than 1 column in projection detached from entity tracker
    var topSalaryEmployee = await context.Employees
        .AsNoTracking()
        .OrderByDescending(e => e.Salary)
        .Select(e => new 
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            Salary = e.Salary
        }).FirstOrDefaultAsync();

    Console.WriteLine($"{topSalaryEmployee.FirstName} {topSalaryEmployee.LastName} {topSalaryEmployee.Salary}");

    int employeeCount = await context.Employees.CountAsync();
    int pageLength = 10;
    int pages = employeeCount / pageLength;

    for (int i = 0; i < pages; i++)
    {
        var employeeList = await context.Employees
            .AsNoTracking()
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Salary = e.Salary
            }).Skip(i * pageLength)
            .Take(pageLength)
            .ToListAsync();

        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Salary}");
        }

        Console.ReadLine();
    }

    // Add a project in DB projects
    // Added in change tracker only
    await context.Projects
        .AddAsync(new Project()
        {
            Name = "Judge",
            StartDate = DateTime.Today,
        });

    // Persist in DB. Saves all the changes from the change tracker, not only the added project
    await context.SaveChangesAsync();
}