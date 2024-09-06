using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;

using static DataConstraints;

public class Client
{
    public Client()
    {
        this.ProductsClients = new HashSet<ProductClient>();
        this.Addresses = new HashSet<Address>();
        this.Invoices = new HashSet<Invoice>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(NumberVatMaxLenght)]
    public string NumberVat { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; }

    public virtual ICollection<ProductClient> ProductsClients { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; }
}
