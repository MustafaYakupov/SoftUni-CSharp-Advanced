using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("SoldProducts")]
public class SoldProductExportDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public ProductsExportDto[] Products { get; set; }
}
