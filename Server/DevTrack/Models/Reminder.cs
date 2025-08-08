using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

[Table("Reminder")]
public partial class Reminder
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Message { get; set; } = null!;

    public TimeOnly Time { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Reminders")]
    public virtual TblUser User { get; set; } = null!;
}
