namespace TravelAgency.DataProcessor.ExportDtos;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TravelAgency.Data.Models;
using static Data.DataConstraints;

[XmlType(nameof(Guide))]
public class ExportGuideDto
{
    [XmlElement(nameof(FullName))]
    public string FullName { get; set; } = null!;

    [XmlArray(nameof(TourPackages))]
    public GuideTourPackagesDto[] TourPackages { get; set; } = null!;

}
