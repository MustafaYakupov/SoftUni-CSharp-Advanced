namespace Cadastre.DataProcessor.ImportDtos
{
    using Cadastre.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using static Data.DataConstraints;

    [XmlType(nameof(Property))]
    public class ImportDistrictPropertiesDto
    {
        [Required]
        [XmlElement(nameof(PropertyIdentifier))]
        [MinLength(PropertyIdentifierMinLength)]
        [MaxLength(PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; } = null!;

        [XmlElement(nameof(Area))]
        [Range(PropertyAreaMinValue, PropertyAreaMaxValue)]
        public int Area { get; set; }

        [XmlElement(nameof(Details))]
        [MinLength(PropertyDetailsMinLength)]
        [MaxLength(PropertyDetailsMaxLength)]
        public string? Details { get; set; }

        [Required]
        [XmlElement(nameof(Address))]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [XmlElement(nameof(DateOfAcquisition))]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
