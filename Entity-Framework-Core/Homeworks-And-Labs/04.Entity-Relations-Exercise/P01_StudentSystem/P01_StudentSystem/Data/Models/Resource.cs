﻿

using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [MaxLength(ValidationConstants.ResourceNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstants.ResourceUrlMaxLength)]  
    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; } = null!;
}
