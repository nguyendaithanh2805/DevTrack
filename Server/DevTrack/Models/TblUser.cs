using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

[Table("TblUser")]
public partial class TblUser
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Analytic? Analytic { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Gamification? Gamification { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<LogEntry> LogEntries { get; set; } = new List<LogEntry>();

    [InverseProperty("User")]
    public virtual ICollection<Mistake> Mistakes { get; set; } = new List<Mistake>();

    [InverseProperty("IdNavigation")]
    public virtual Progress? Progress { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

    [InverseProperty("User")]
    public virtual ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
}
