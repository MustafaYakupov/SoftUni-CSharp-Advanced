namespace TravelAgency.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using TravelAgency.Data.Models;
    using static Data.DataConstraints;

    [XmlType(nameof(Customer))]
    public class ImportCustomerDto
    {
        [Required]
        [XmlElement(nameof(FullName))]
        [MinLength(CustomerFullNameMinLength)]
        [MaxLength(CustomerFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [XmlElement(nameof(Email))]
        [MinLength(CustomerEmailMinLength)]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [XmlAttribute("phoneNumber")]
        [RegularExpression(CustomerPhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;
    }
}
