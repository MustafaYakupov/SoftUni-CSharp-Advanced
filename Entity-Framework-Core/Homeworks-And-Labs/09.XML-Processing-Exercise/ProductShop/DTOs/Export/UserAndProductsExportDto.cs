using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("Users")]
public class UserAndProductsExportDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlElement("users")]
    public UsersExportDto[] Users { get; set; }
}
