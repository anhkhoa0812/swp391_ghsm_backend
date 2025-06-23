using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repository.Models.Enum;

namespace Repository.Models;

[Table("TestBooking")]
public partial class TestBooking
{
    [Key]
    [Column("testBookingId")]
    public Guid TestBookingId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("testId")]
    public Guid TestId { get; set; }

    [Column("scheduledDate", TypeName = "datetime")]
    public DateTime ScheduledDate { get; set; }

    [Column("status")]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; }

    //[Column("scheduleId")]
    //public Guid? ScheduleId { get; set; }

    [InverseProperty("TestBooking")]
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    //[ForeignKey("ScheduleId")]
    //[InverseProperty("TestBookings")]
    //public virtual ConsultantUserSchedule? Schedule { get; set; }

    [ForeignKey("TestId")]
    [InverseProperty("TestBookings")]
    public virtual Test Test { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("TestBookings")]
    public virtual User User { get; set; } = null!;
}
