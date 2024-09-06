// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using ORMDemo;

Console.WriteLine("Hello, World!");

var context = new ApplicationDbContext();

// Classic LINQ
var result = from employee 
             in context.Employees 
             where employee.FirstName == "Pesho" 
             select employee;

// Moders LINQ with extension methods
var result1 =  context.Employees
    .Where(e => e.FirstName == "Pesho"); //  This is IQuerable - Expression tree, NOT MATERIALIZED COLLECTION

var materializedResult1 = await result1.ToListAsync(); // Materialized expression tree into List collection

var employee1 = context.Employees.Find(2); // Checks the entity tracker first and returns result from there if found. If not found searches the DB

// Getting information from the DB detaching the tracker. 
var detachedFromTracking = context.Employees
    .Where(e => e.FirstName == "Pesho")
    .AsNoTracking()
    .ToList();

// Save changes in DB
context.SaveChanges();
