﻿using P01_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    public Student()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
        this.Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.StudentNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstants.PhoneNumberMaxLength)]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
}