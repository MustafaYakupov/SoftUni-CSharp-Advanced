﻿namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Data.DataConstraints;

public class Booking
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime BookingDate { get; set; }

    public int CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; } = null!;

    public int TourPackageId { get; set; }

    [ForeignKey(nameof(TourPackageId))]
    public virtual TourPackage TourPackage { get; set; } = null!;
}
