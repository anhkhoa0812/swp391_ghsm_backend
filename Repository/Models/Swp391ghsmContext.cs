using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Models;

public partial class Swp391ghsmContext : DbContext
{
    public Swp391ghsmContext()
    {
    }

    public Swp391ghsmContext(DbContextOptions<Swp391ghsmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<Consultant> Consultants { get; set; }

    public virtual DbSet<ConsultantUserSchedule> ConsultantUserSchedules { get; set; }

    public virtual DbSet<ConsultationBooking> ConsultationBookings { get; set; }

    public virtual DbSet<Ewallet> Ewallets { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<LastUserMessage> LastUserMessages { get; set; }

    public virtual DbSet<MenstrualCycle> MenstrualCycles { get; set; }

    public virtual DbSet<OvulationReminder> OvulationReminders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestBooking> TestBookings { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserMessage> UserMessages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=160.191.244.31,1433; Database=SWP391GHSM;User Id=sa;Password=123456aA@$;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blog__FA0AA72D39F9F7A3");

            entity.Property(e => e.BlogId).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Author).WithMany(p => p.Blogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Blog__authorId__7A672E12");
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasOne(d => d.GroupNameNavigation).WithMany(p => p.Connections).HasConstraintName("FK_Connection_Group");
        });

        modelBuilder.Entity<Consultant>(entity =>
        {
            entity.HasKey(e => e.ConsultantId).HasName("PK__Consulta__8E3CA2FFFF64B9FB");

            entity.Property(e => e.ConsultantId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Consultants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultan__userI__7B5B524B");
        });

        modelBuilder.Entity<ConsultantUserSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Consulta__A532EDD46A7CD89D");

            entity.Property(e => e.ScheduleId).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("PENDING");

            entity.HasOne(d => d.Consultant).WithMany(p => p.ConsultantUserSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultan__consu__7C4F7684");

            entity.HasOne(d => d.ConsultationBooking).WithMany(p => p.ConsultantUserSchedules).HasConstraintName("FK__Consultan__consu__7D439ABD");

            entity.HasOne(d => d.User).WithMany(p => p.ConsultantUserSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultan__userI__7E37BEF6");
        });

        modelBuilder.Entity<ConsultationBooking>(entity =>
        {
            entity.HasKey(e => e.ConsultationBookingId).HasName("PK__Consulta__3CF475EFD8FD77B8");

            entity.Property(e => e.ConsultationBookingId).ValueGeneratedNever();
            entity.Property(e => e.Status).HasDefaultValue("PENDING");

            entity.HasOne(d => d.Consultant).WithMany(p => p.ConsultationBookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultat__consu__7F2BE32F");

            entity.HasOne(d => d.User).WithMany(p => p.ConsultationBookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Consultat__userI__00200768");
        });

        modelBuilder.Entity<Ewallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK__EWallet__3785C8705A366EBA");

            entity.Property(e => e.WalletId).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Ewallets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EWallet_User");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__2613FD24B26DAB93");

            entity.Property(e => e.FeedbackId).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ConsultationBooking).WithMany(p => p.Feedbacks).HasConstraintName("FK__Feedback__consul__02084FDA");

            entity.HasOne(d => d.TestBooking).WithMany(p => p.Feedbacks).HasConstraintName("FK__Feedback__testBo__02FC7413");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__userId__03F0984C");
        });

        modelBuilder.Entity<LastUserMessage>(entity =>
        {
            entity.HasKey(e => e.LastUserMessageId).HasName("PK_Message");

            entity.Property(e => e.LastUserMessageId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");
        });

        modelBuilder.Entity<MenstrualCycle>(entity =>
        {
            entity.HasKey(e => e.CyclesId).HasName("PK__Menstrua__674DB3A5B82EED54");

            entity.Property(e => e.CyclesId).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.MenstrualCycles).HasConstraintName("FK_MenstrualCycles_User");
        });

        modelBuilder.Entity<OvulationReminder>(entity =>
        {
            entity.HasKey(e => e.ReminderId).HasName("PK__Ovulatio__09DAAAE304E4B69E");

            entity.Property(e => e.ReminderId).ValueGeneratedNever();

            entity.HasOne(d => d.Cycles).WithMany(p => p.OvulationReminders).HasConstraintName("FK_OvulationReminders_Cycles");

            entity.HasOne(d => d.User).WithMany(p => p.OvulationReminders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OvulationReminders_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__A0D9EFC63B866F76");

            entity.Property(e => e.PaymentId).ValueGeneratedNever();
            entity.Property(e => e.Status).HasDefaultValue("PENDING");
            entity.Property(e => e.TransactionTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Wallet).WithMany(p => p.Payments).HasConstraintName("FK_Payment_EWallet");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__6238D4B2CC7E42A4");

            entity.Property(e => e.QuestionId).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Consultant).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Question__consul__08B54D69");

            entity.HasOne(d => d.User).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Question__userId__09A971A2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__CD98462AAAD97651");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.TestId).HasName("PK__Test__A29BFB88458D99EA");

            entity.Property(e => e.TestId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TestBooking>(entity =>
        {
            entity.HasKey(e => e.TestBookingId).HasName("PK__TestBook__383DA4ED7A901360");

            entity.Property(e => e.TestBookingId).ValueGeneratedNever();
            entity.Property(e => e.Status).HasDefaultValue("PENDING");

            entity.HasOne(d => d.Schedule).WithMany(p => p.TestBookings).HasConstraintName("FK_TestBooking_Schedule");

            entity.HasOne(d => d.Test).WithMany(p => p.TestBookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestBooki__testI__0A9D95DB");

            entity.HasOne(d => d.User).WithMany(p => p.TestBookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestBooki__userI__0B91BA14");
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__TestResu__C6EADC5BCC8044CC");

            entity.Property(e => e.ResultId).ValueGeneratedNever();

            entity.HasOne(d => d.Test).WithMany(p => p.TestResults)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestResul__testI__0D7A0286");

            entity.HasOne(d => d.User).WithMany(p => p.TestResults)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestResul__userI__0E6E26BF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__CB9A1CFF2BDD6882");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__roleId__0F624AF8");
        });

        modelBuilder.Entity<UserMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__UserMess__4808B9933255B7A7");

            entity.Property(e => e.MessageId).ValueGeneratedNever();
            entity.Property(e => e.SentAt).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
