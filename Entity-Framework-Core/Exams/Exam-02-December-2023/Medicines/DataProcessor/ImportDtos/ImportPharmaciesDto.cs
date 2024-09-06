using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos;

using static Data.DataConstraints;

[XmlType(nameof(Pharmacy))]
public class ImportPharmaciesDto
{
    [XmlElement(nameof(Name))]
    [Required]
    [MinLength(PharmacyNameMinLength)]
    [MaxLength(PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(PhoneNumber))]
    [Required]
    [RegularExpression(PharmacyPhoneNumberRegex)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [XmlAttribute("non-stop")]
    [RegularExpression(PharmacyBooleanRegex)]
    public string IsNonStop { get; set; } = null!; // Bool as string for validation then bool.Parse in Deserializer

    public ImportMedicinesDto[] Medicines { get; set; } = null!;
}
