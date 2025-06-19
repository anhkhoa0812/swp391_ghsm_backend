using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid UserId { get; set; }

    public Guid? TestBooking { get; set; }

    public decimal Amount { get; set; }

    public string Method { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? TransactionTime { get; set; }

    public virtual TestBooking? TestBookingNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
