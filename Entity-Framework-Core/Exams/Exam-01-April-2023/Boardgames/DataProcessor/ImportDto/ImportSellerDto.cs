﻿namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstraints;

public class ImportSellerDto
{
    [Required]
    [MinLength(SellerNameMinLength)]
    [MaxLength(SellerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(SellerAddressMinLength)]
    [MaxLength(SellerAddressMaxLength)]
    public string Address { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(SellerWebsiteRegex)]
    public  string Website { get; set; } = null!;

    [Required]
    public int[] Boardgames { get; set; }
}
