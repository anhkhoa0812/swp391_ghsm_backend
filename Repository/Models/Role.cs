using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("Role")]
[Index("RoleName", Name = "UQ__Role__B194786130E93023", IsUnique = true)]
public partial class Role
{
    [Key]
    [Column("roleId")]
    public Guid RoleId { get; set; }

    [Column("roleName")]
    [StringLength(50)]
    [Unicode(false)]
    public string RoleName { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
