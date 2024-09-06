namespace Cadastre.Data.Models;

using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using static Data.DataConstraints;

public class Citizen
{
    public Citizen()
    {
        this.PropertiesCitizens = new HashSet<PropertyCitizen>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CitizenFirstAndLastNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(CitizenFirstAndLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public MaritalStatus MaritalStatus { get; set; }

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
}
