namespace Invoices.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

using static Data.DataConstraints;

public class ImportProductDto
{
    [Required]
    [MinLength(ProductNameMinLength)]
    [MaxLength(ProductNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Range(typeof(decimal), ProductPriceMinvalue, ProductPriceMaxvalue)] // Constraints must be string to be able to cast them to decimal in Range attribute
    public decimal Price { get; set; }

    [Required]
    [Range(ProductCategoryTypeMinValue, ProductCategoryTypeMaxValue)]
    public int CategoryType { get; set; }

    [Required]
    public int[] Clients { get; set; } = null!;
}
