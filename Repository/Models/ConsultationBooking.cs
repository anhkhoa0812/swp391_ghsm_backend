﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class ConsultationBooking
{
    [Key]
    [Column("consultationBookingId")]
    public Guid ConsultationBookingId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("consultantId")]
    public Guid ConsultantId { get; set; }

    [Column("datetime", TypeName = "datetime")]
    public DateTime Datetime { get; set; }

    [Column("title")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Title { get; set; }

    [Column("linkConsultation")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LinkConsultation { get; set; }

    [Column("status")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [ForeignKey("ConsultantId")]
    [InverseProperty("ConsultationBookings")]
    public virtual Consultant Consultant { get; set; } = null!;

    //[InverseProperty("ConsultationBooking")]
    //public virtual ICollection<ConsultantUserSchedule> ConsultantUserSchedules { get; set; } = new List<ConsultantUserSchedule>();

    [InverseProperty("ConsultationBooking")]
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    [ForeignKey("UserId")]
    [InverseProperty("ConsultationBookings")]
    public virtual User User { get; set; } = null!;
}
