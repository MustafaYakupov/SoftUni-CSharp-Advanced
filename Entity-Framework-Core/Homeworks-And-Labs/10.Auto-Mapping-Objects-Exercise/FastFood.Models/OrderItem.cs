namespace FastFood.Models;

using FastFood.Common.EntityConfiguration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderItem
{
    [Key]
    public string OrderId { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; } = null!;

    public string ItemId { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ItemId))]
    public virtual Item Item { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}