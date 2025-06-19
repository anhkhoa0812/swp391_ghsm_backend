﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("TestResult")]
public partial class TestResult
{
    [Key]
    [Column("resultId")]
    public Guid ResultId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("testId")]
    public Guid TestId { get; set; }

    [Column("typeSTIs")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TypeStis { get; set; }

    [Column("testSample")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TestSample { get; set; }

    [Column("testBlood")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TestBlood { get; set; }

    [Column("testUrine")]
    [StringLength(100)]
    [Unicode(false)]
    public string? TestUrine { get; set; }

    [Column("diagnosticResults", TypeName = "text")]
    public string? DiagnosticResults { get; set; }

    [ForeignKey("TestId")]
    [InverseProperty("TestResults")]
    public virtual Test Test { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("TestResults")]
    public virtual User User { get; set; } = null!;
}
