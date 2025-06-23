﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

[Table("User")]
[Index("Email", Name = "UQ__User__AB6E6164389781CB", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("userId")]
    public Guid UserId { get; set; }

    [Column("fullName")]
    [StringLength(100)]
    [Unicode(false)]
    public string FullName { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("passwordHash")]
    [StringLength(255)]
    [Unicode(false)]
    public string PasswordHash { get; set; } = null!;

    [Column("phoneNumber")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column("gender")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Gender { get; set; }

    [Column("address")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column("roleId")]
    public Guid RoleId { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("isActive")]
    public bool? IsActive { get; set; }

    [Column("avatar")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Avatar { get; set; }

    [InverseProperty("Author")]
    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    //[InverseProperty("User")]
    //public virtual ICollection<ConsultantUserSchedule> ConsultantUserSchedules { get; set; } = new List<ConsultantUserSchedule>();

    [InverseProperty("User")]
    public virtual ICollection<Consultant> Consultants { get; set; } = new List<Consultant>();

    [InverseProperty("User")]
    public virtual ICollection<ConsultationBooking> ConsultationBookings { get; set; } = new List<ConsultationBooking>();

    [InverseProperty("User")]
    public virtual ICollection<Ewallet> Ewallets { get; set; } = new List<Ewallet>();

    [InverseProperty("User")]
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    [InverseProperty("User")]
    public virtual ICollection<MenstrualCycle> MenstrualCycles { get; set; } = new List<MenstrualCycle>();

    [InverseProperty("User")]
    public virtual ICollection<OvulationReminder> OvulationReminders { get; set; } = new List<OvulationReminder>();

    [InverseProperty("User")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]  
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<TestBooking> TestBookings { get; set; } = new List<TestBooking>();

    [InverseProperty("User")]
    public virtual ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();
}
