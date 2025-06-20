﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("Feedback")]
public partial class Feedback
{
    [Key]
    [Column("feedbackId")]
    public Guid FeedbackId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("testBookingId")]
    public Guid? TestBookingId { get; set; }

    [Column("consultationBookingId")]
    public Guid? ConsultationBookingId { get; set; }

    [Column("rating")]
    public int? Rating { get; set; }

    [Column("comment", TypeName = "text")]
    public string? Comment { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("ConsultationBookingId")]
    [InverseProperty("Feedbacks")]
    public virtual ConsultationBooking? ConsultationBooking { get; set; }

    [ForeignKey("TestBookingId")]
    [InverseProperty("Feedbacks")]
    public virtual TestBooking? TestBooking { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Feedbacks")]
    public virtual User User { get; set; } = null!;
}
