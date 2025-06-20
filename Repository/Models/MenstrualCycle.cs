﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class MenstrualCycle
{
    [Key]
    [Column("cyclesId")]
    public Guid CyclesId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("startDate")]
    public DateOnly StartDate { get; set; }

    [Column("endDate")]
    public DateOnly EndDate { get; set; }

    [Column("averageLength")]
    public int AverageLength { get; set; }

    [InverseProperty("Cycles")]
    public virtual ICollection<OvulationReminder> OvulationReminders { get; set; } = new List<OvulationReminder>();

    [ForeignKey("UserId")]
    [InverseProperty("MenstrualCycles")]
    public virtual User User { get; set; } = null!;
}
