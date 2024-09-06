using System.ComponentModel.DataAnnotations;

namespace StudentsSystem.Data.Models;

public class Student
{
    public Student()
    {
        StudentCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int StudentId { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime Birthday { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
}
