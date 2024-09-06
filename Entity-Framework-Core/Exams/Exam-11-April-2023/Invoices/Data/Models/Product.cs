namespace Invoices.Data.Models;

using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

using static DataConstraints;

public class Product
{
    public Product()
    {
        this.ProductsClients = new HashSet<ProductClient>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ProductNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    // Enumeration is stored in the DB as INT -> By default enum is required
    [Required]
    public CategoryType CategoryType  { get; set; }

    public virtual ICollection<ProductClient> ProductsClients { get; set; }
}
