using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class MenstrualCycle
{
    public Guid CyclesId { get; set; }

    public Guid UserId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? AverageLength { get; set; }

    public virtual User User { get; set; } = null!;
}
