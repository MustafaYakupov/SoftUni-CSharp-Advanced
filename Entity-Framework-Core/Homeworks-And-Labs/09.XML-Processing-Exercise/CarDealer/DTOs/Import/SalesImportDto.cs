﻿using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Sale")]
public class SalesImportDto
{
    [XmlElement("discount")]
    public decimal Discount { get; set; }

    [XmlElement("carId")]
    public int CarId { get; set; }

    [XmlElement("customerId")]
    public int CustomerId { get; set; }
}
