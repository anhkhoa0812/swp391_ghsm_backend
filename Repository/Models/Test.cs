using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("Test")]
public partial class Test
{
    [Key]
    [Column("testId")]
    public Guid TestId { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }
    public bool isBooked {  get; set; }
    public bool isDelete { get; set; }

    [Column("consutantId")]
    public Guid ConsutantId {  get; set; }

    [InverseProperty("Test")]
    public virtual ICollection<TestBooking> TestBookings { get; set; } = new List<TestBooking>();

    [InverseProperty("Test")]
    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();

    [ForeignKey("ConsutantId")]
    public virtual Consultant Consultants { get; set; }
}
