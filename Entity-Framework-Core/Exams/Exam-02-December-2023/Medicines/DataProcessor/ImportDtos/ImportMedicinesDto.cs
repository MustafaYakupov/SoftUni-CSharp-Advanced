namespace Medicines.DataProcessor.ImportDtos;

using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static Data.DataConstraints;

[XmlType(nameof(Medicine))]
public class ImportMedicinesDto
{
    [Required]
    [XmlElement(nameof(Name))]
    [MaxLength(MedicineNameMaxLength)]
    [MinLength(MedicineNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Price))]
    [Range(typeof(decimal), MedicinePriceMinValue, MedicinePriceMaxValue)] // Constraints must be string to be able to cast them to decimal in Range attribute
    public decimal Price { get; set; }

    [Required]
    [XmlElement(nameof(ProductionDate))]
    public string ProductionDate { get; set; } = null!;

    [Required]
    [XmlElement(nameof(ExpiryDate))]
    public string ExpiryDate { get; set; } = null!;

    [Required]
    [XmlElement(nameof(Producer))]
    [MaxLength(MedicineProducerNameMaxLenth)]
    [MinLength(MedicineProducerNameMinLenth)]
    public  string Producer { get; set; } = null!;

    [Required]
    [XmlAttribute("category")]
    [Range(MedicineCategoryMinValue, MedicineCategoryMaxValue)]  // Validate  enum range
    public int Category { get; set; } // Enum -> Deserialize as int
}
