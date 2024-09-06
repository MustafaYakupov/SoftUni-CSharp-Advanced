namespace TravelAgency.DataProcessor.ExportDtos;

using System.Xml.Serialization;
using TravelAgency.Data.Models;
using static Data.DataConstraints;

[XmlType(nameof(TourPackage))]
public class GuideTourPackagesDto
{
    [XmlElement(nameof(Name))]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(Description))]
    public string? Description { get; set; }

    [XmlElement(nameof(Price))]
    public decimal Price { get; set; }
}
