using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("ConsultantUserSchedule")]
public partial class ConsultantUserSchedule
{
    [Key]
    [Column("scheduleId")]
    public Guid ScheduleId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("consultantId")]
    public Guid ConsultantId { get; set; }

    [Column("consultationBookingId")]
    public Guid? ConsultationBookingId { get; set; }

    [Column("scheduleDateTime", TypeName = "datetime")]
    public DateTime ScheduleDateTime { get; set; }

    [Column("durationMinutes")]
    public int? DurationMinutes { get; set; }

    [Column("status")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("notes", TypeName = "text")]
    public string? Notes { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("ConsultantId")]
    [InverseProperty("ConsultantUserSchedules")]
    public virtual Consultant Consultant { get; set; } = null!;

    [ForeignKey("ConsultationBookingId")]
    [InverseProperty("ConsultantUserSchedules")]
    public virtual ConsultationBooking? ConsultationBooking { get; set; }

    [InverseProperty("Schedule")]
    public virtual ICollection<TestBooking> TestBookings { get; set; } = new List<TestBooking>();

    [ForeignKey("UserId")]
    [InverseProperty("ConsultantUserSchedules")]
    public virtual User User { get; set; } = null!;
}
