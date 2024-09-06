namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Data.DataConstraints;

public class Customer
{
    public Customer()
    {
        this.Bookings = new HashSet<Booking>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CustomerFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [MaxLength(CustomerEmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; }
}
