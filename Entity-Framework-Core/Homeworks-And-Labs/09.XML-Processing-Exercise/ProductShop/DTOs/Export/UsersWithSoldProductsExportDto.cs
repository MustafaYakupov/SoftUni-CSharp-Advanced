using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("User")]
public class UsersWithSoldProductsExportDto
{
    [XmlElement("firstName")]
    public string FristName { get; set; }

    [XmlElement("lastName")]
    public string LastName { get; set; }

    [XmlArray("soldProducts")]
    public SoldProductsOfUsersDto[] SoldProducts { get; set; } 
}
