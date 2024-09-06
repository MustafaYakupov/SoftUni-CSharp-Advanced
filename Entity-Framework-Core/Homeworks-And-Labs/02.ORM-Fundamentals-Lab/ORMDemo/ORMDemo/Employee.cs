using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMDemo
{
    internal class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))] // Shows the navigation property is referncing to DepartmentId
        public Department Department { get; set; }  // Navigation property. Saves the department of the employee. One department
    }
}
