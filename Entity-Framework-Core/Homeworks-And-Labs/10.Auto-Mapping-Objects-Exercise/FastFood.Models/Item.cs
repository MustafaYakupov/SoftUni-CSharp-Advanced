﻿namespace FastFood.Models;

using FastFood.Common.EntityConfiguration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Item
{
    public Item()
    {
        this.Id = Guid.NewGuid().ToString();
    }

    [Key]
    public string Id { get; set; }

    [StringLength(EntitiesValidation.ItemNameMaxLength, MinimumLength = 3)]
    public string? Name { get; set; }

    public int CategoryId { get; set; }

    [Required]
    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } = null!;

    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
    public decimal Price { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}