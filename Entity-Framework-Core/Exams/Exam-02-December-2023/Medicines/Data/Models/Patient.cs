namespace Medicines.Data.Models;

using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

using static Data.DataConstraints;

public class Patient
{
    public Patient()
    {
        this.PatientsMedicines = new HashSet<PatientMedicine>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PatientNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    public AgeGroup AgeGroup { get; set; }

    [Required]
    public Gender Gender { get; set; }

    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }
}
