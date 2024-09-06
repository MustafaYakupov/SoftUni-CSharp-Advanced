using System.Xml.Serialization;

namespace ProductShop.DTOs.Import;

[XmlType("User")]
public class UsersImportDto
{
    [XmlElement("firstName")]
    public string Firstname { get; set; }

    [XmlElement("lastName")]
    public string LastName { get; set; }

    [XmlElement("age")]
    public int Age { get; set; }
}
