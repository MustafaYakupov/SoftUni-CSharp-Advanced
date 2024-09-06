namespace Invoices.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DataConstraints;

public class Address
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(AddressStreetNameMaxLength)]
    public string StreetName { get; set; } = null!;

    [Required]
    public int StreetNumber { get; set; }

    [Required]
    public string PostCode { get; set; } = null!; // NVARCHAR(MAX)

    [Required]
    [MaxLength(AddressCityMaxLength)]
    public string City { get; set; } = null!;

    [Required]
    [MaxLength(CountryMaxLength)]
    public string Country { get; set; } = null!;

    public int ClientId { get; set; }

    [ForeignKey(nameof(ClientId))] 
    public virtual Client Client { get; set; } = null!;
}
