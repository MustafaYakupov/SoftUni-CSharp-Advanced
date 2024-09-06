
using System.ComponentModel.DataAnnotations;

namespace StudentsSystem.Data.Models;

public class Course
{
    public Course()
    {
        StudentCourses = new HashSet<StudentCourse>();
        Resources = new HashSet<Resource>();
    }

    [Key]
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public ICollection<Resource> Resources { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }

}
