﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("Question")]
public partial class Question
{
    [Key]
    [Column("questionId")]
    public Guid QuestionId { get; set; }

    [Column("consultantId")]
    public Guid ConsultantId { get; set; }

    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("questionText", TypeName = "text")]
    public string QuestionText { get; set; } = null!;

    [Column("answerText", TypeName = "text")]
    public string? AnswerText { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("ConsultantId")]
    [InverseProperty("Questions")]
    public virtual Consultant Consultant { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Questions")]
    public virtual User User { get; set; } = null!;
}
