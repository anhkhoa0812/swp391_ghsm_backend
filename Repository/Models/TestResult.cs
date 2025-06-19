﻿using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class TestResult
{
    public Guid ResultId { get; set; }

    public Guid UserId { get; set; }

    public Guid TestId { get; set; }

    public string? TypeStis { get; set; }

    public string? TestSample { get; set; }

    public string? TestBlood { get; set; }

    public string? TestUrine { get; set; }

    public string? DiagnosticResults { get; set; }

    public virtual Test Test { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
