﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Consultant
{
    [Key]
    [Column("consultantId")]
    public Guid ConsultantId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("degree")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Degree { get; set; }

    [Column("experienceYears")]
    public int? ExperienceYears { get; set; }

    [Column("bio", TypeName = "text")]
    public string? Bio { get; set; }

    [Column("avatar")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Avatar { get; set; }

    [InverseProperty("Consultant")]
    public virtual ICollection<ConsultantUserSchedule> ConsultantUserSchedules { get; set; } = new List<ConsultantUserSchedule>();

    [InverseProperty("Consultant")]
    public virtual ICollection<ConsultationBooking> ConsultationBookings { get; set; } = new List<ConsultationBooking>();

    [InverseProperty("Consultant")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [ForeignKey("UserId")]
    [InverseProperty("Consultants")]
    public virtual User User { get; set; } = null!;
}
