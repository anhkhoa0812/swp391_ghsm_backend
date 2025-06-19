using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class ConsultantUserSchedule
{
    public Guid ScheduleId { get; set; }

    public Guid UserId { get; set; }

    public Guid ConsultantId { get; set; }

    public Guid? ConsultationBookingId { get; set; }

    public DateTime ScheduleDateTime { get; set; }

    public int? DurationMinutes { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Consultant Consultant { get; set; } = null!;

    public virtual ConsultationBooking? ConsultationBooking { get; set; }

    public virtual User User { get; set; } = null!;
}
