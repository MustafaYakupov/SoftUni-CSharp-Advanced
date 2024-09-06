namespace Cadastre.Data.Models;

using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using static Data.DataConstraints;

public class District
{
    public District()
    {
        this.Properties = new HashSet<Property>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(DistrictNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(DistrictPostalCodeMaxLength)]
    public string PostalCode { get; set; } = null!;

    public Region Region { get; set; }

    public virtual ICollection<Property> Properties { get; set; }

}
