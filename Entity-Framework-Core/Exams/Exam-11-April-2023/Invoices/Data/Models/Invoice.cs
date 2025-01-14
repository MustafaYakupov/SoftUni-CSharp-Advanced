﻿namespace Invoices.Data.Models;

using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Invoice
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    public DateTime IssueDate { get; set; } // DATETIME2 -> by default required

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public CurrencyType CurrencyType { get; set; }

    public int ClientId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public virtual Client Client { get; set; } = null!;
}
