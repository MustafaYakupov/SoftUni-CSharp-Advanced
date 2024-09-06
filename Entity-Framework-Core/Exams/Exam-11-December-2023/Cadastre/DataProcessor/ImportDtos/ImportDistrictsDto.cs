namespace Cadastre.DataProcessor.ImportDtos;

using Cadastre.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Data.DataConstraints;

[XmlType(nameof(District))]
public class ImportDistrictsDto
{
    [Required]
    [XmlElement(nameof(Name))]
    [MinLength(DistrictNameMinLength)]
    [MaxLength(DistrictNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [RegularExpression(DistrictPostalCodeRegex)]
    [MinLength(DistrictPostalCodeMinLength)]
    [MaxLength(DistrictPostalCodeMaxLength)]
    [XmlElement(nameof(PostalCode))]
    public string PostalCode { get; set; } = null!;

    [Required]
    [XmlAttribute(nameof(Region))]
    public string Region { get; set; } = null!;

    [Required]
    [XmlArray(nameof(Properties))]
    public ImportDistrictPropertiesDto[] Properties { get; set; } = null!;
}
