﻿namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Models.Enums;
using static Data.DataConstraints;

public class Guide
{
    public Guide()
    {
        this.TourPackagesGuides = new HashSet<TourPackageGuide>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GuideFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    public Language Language { get; set; }

    public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
}
