namespace Medicines.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Medicines.Data.Models.Enums;
using static Data.DataConstraints;

public class Medicine
{
    public Medicine()
    {
        this.PatientsMedicines = new HashSet<PatientMedicine>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public Category Category { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Required]
    [MaxLength(MedicineProducerNameMaxLenth)]
    public string Producer { get; set; } = null!;

    [Required]
    public int PharmacyId { get; set; }

    [ForeignKey(nameof(PharmacyId))]
    public virtual Pharmacy Pharmacy { get; set; } = null!;

    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }

}
