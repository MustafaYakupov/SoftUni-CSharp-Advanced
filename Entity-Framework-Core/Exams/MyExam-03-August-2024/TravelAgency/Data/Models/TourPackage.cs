namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Data.DataConstraints;

public class TourPackage
{
    public TourPackage()
    {
        this.TourPackagesGuides = new HashSet<TourPackageGuide>();
        this.Bookings = new HashSet<Booking>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TourPackageNameMaxLength)]
    public string PackageName { get; set; } = null!;

    [MaxLength(TourPackageDescriptionMaxLength)]
    public string? Description { get; set; }  // Not required

    [Required]
    public decimal Price { get; set; }

    public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; }
}
