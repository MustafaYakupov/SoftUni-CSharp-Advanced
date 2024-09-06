namespace Cadastre.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Data.DataConstraints;

public class Property
{
    public Property()
    {
        this.PropertiesCitizens = new HashSet<PropertyCitizen>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; } = null!;
    
    public int Area { get; set; }

    [MaxLength(PropertyDetailsMaxLength)]
    public string? Details { get; set; } // Not required

    [Required]
    [MaxLength(PropertyAddressMaxLength)]
    public string Address { get; set; } = null!;

    public DateTime DateOfAcquisition { get; set; }

    public int DistrictId { get; set; }

    [ForeignKey(nameof(DistrictId))]
    public virtual District District { get; set; }

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
}
