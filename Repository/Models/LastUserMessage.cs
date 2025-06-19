﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("LastUserMessage")]
public partial class LastUserMessage
{
    [Key]
    public Guid LastUserMessageId { get; set; }

    [StringLength(255)]
    public string SenderEmail { get; set; } = null!;

    [StringLength(255)]
    public string ReceiverEmail { get; set; } = null!;

    [StringLength(500)]
    public string? SenderAvatarUrl { get; set; }

    [StringLength(500)]
    public string? ReceiverAvatarUrl { get; set; }

    [Column(TypeName = "ntext")]
    public string Message { get; set; } = null!;

    public DateTime MessageLastDate { get; set; }

    [StringLength(255)]
    public string GroupName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
