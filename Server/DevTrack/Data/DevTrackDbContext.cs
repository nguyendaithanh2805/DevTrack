using System;
using System.Collections.Generic;
using DevTrack.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Data;

public partial class DevTrackDbContext : DbContext
{
    public DevTrackDbContext()
    {
    }

    public DevTrackDbContext(DbContextOptions<DevTrackDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Analytic> Analytics { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Gamification> Gamifications { get; set; }

    public virtual DbSet<LogEntry> LogEntries { get; set; }

    public virtual DbSet<Mistake> Mistakes { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Reminder> Reminders { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<UserBadge> UserBadges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4QE7N69\\SQLEXPRESS;Database=DevTrack_Db;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analytic>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Analytic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Analytics");
        });

        modelBuilder.Entity<Gamification>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Gamification)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Gamification");
        });

        modelBuilder.Entity<LogEntry>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.LogEntries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_LogEntry");

            entity.HasMany(d => d.Tags).WithMany(p => p.LogEntries)
                .UsingEntity<Dictionary<string, object>>(
                    "LogEntryTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Tag_LogEntryTag"),
                    l => l.HasOne<LogEntry>().WithMany()
                        .HasForeignKey("LogEntryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LogEntry_LogEntryTag"),
                    j =>
                    {
                        j.HasKey("LogEntryId", "TagId");
                        j.ToTable("LogEntryTag");
                    });
        });

        modelBuilder.Entity<Mistake>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Mistakes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Mistake");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Progress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Progress");
        });

        modelBuilder.Entity<Reminder>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Reminders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Reminder");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");
        });

        modelBuilder.Entity<UserBadge>(entity =>
        {
            entity.HasOne(d => d.Badge).WithMany(p => p.UserBadges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Badge_UserBadge");

            entity.HasOne(d => d.User).WithMany(p => p.UserBadges)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_UserBadge");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
