using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("Group")]
public partial class Group
{
    [Key]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [InverseProperty("GroupNameNavigation")]
    public virtual ICollection<Connection> Connections { get; set; } = new List<Connection>();
}
