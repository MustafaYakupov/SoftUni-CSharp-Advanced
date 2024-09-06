using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Car")]
public class CarsImportDto
{
    [XmlElement("make")]
    public string Make { get; set; }

    [XmlElement("model")]
    public string Model { get; set; }

    [XmlElement("travelledDistance")]
    public long TravelledDistance { get; set; }

    [XmlArray("parts")]
    public PartsCarsImportDto[] PartIds { get; set; }
}
