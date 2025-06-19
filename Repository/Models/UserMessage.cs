using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("UserMessage")]
public partial class UserMessage
{
    [Key]
    [Column("messageId")]
    public Guid MessageId { get; set; }

    [Column("message", TypeName = "text")]
    public string Message { get; set; } = null!;

    [Column("sentAt", TypeName = "datetime")]
    public DateTime? SentAt { get; set; }

    [Column("senderEmail")]
    [StringLength(255)]
    public string SenderEmail { get; set; } = null!;

    [Column("receiverEmail")]
    [StringLength(255)]
    public string ReceiverEmail { get; set; } = null!;
}
