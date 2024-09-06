namespace Invoices.DataProcessor.ImportDto;

using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static Data.DataConstraints;

[XmlType(nameof(Client))]
public class ImportClientDto
{
    [XmlElement(nameof(Name))]
    [Required]
    [MinLength(ClientNameMinLength)]
    [MaxLength(ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(NumberVat))]
    [Required]
    [MinLength(NumberVatMinLenght)]
    [MaxLength(NumberVatMaxLenght)]
    public string NumberVat { get; set; } = null!;

    [XmlArray(nameof(Addresses))]
    public ImportAddressDto[] Addresses { get; set; } = null!;
}
