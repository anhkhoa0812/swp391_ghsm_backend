﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("Connection")]
public partial class Connection
{
    [Key]
    [StringLength(255)]
    public string ConnectionId { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string GroupName { get; set; } = null!;

    [ForeignKey("GroupName")]
    [InverseProperty("Connections")]
    public virtual Group GroupNameNavigation { get; set; } = null!;
}
