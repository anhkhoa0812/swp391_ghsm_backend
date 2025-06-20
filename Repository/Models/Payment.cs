using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("Payment")]
public partial class Payment
{
    [Key]
    [Column("paymentId")]
    public Guid PaymentId { get; set; }

    [Column("amount", TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [Column("method")]
    [StringLength(50)]
    [Unicode(false)]
    public string Method { get; set; } = null!;

    [Column("status")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("transactionTime", TypeName = "datetime")]
    public DateTime? TransactionTime { get; set; }

    [Column("walletId")]
    public Guid? WalletId { get; set; }

    [ForeignKey("WalletId")]
    [InverseProperty("Payments")]
    public virtual Ewallet? Wallet { get; set; }
}
