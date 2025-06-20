﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class OvulationReminder
{
    [Key]
    [Column("reminderId")]
    public Guid ReminderId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("cyclesId")]
    public Guid CyclesId { get; set; }

    [Column("reminderDate")]
    public DateOnly ReminderDate { get; set; }

    [Column("type")]
    [StringLength(50)]
    public string? Type { get; set; }

    [Column("note")]
    [StringLength(255)]
    public string? Note { get; set; }

    [Column("cycleDay")]
    public int? CycleDay { get; set; }

    [ForeignKey("CyclesId")]
    [InverseProperty("OvulationReminders")]
    public virtual MenstrualCycle Cycles { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("OvulationReminders")]
    public virtual User User { get; set; } = null!;
}
