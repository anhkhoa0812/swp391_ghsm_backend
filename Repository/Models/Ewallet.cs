using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("EWallet")]
public partial class Ewallet
{
    [Key]
    [Column("walletId")]
    public Guid WalletId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("balance", TypeName = "decimal(18, 2)")]
    public decimal Balance { get; set; }

    [Column("lastUpdated", TypeName = "datetime")]
    public DateTime LastUpdated { get; set; }

    [Column("isActive")]
    public bool IsActive { get; set; }

    [InverseProperty("Wallet")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("UserId")]
    [InverseProperty("Ewallets")]
    public virtual User User { get; set; } = null!;
}
