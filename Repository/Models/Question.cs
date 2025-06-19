using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Question
{
    public Guid QuestionId { get; set; }

    public Guid ConsultantId { get; set; }

    public Guid UserId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string? AnswerText { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Consultant Consultant { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
