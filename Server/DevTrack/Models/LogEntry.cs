using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

[Table("LogEntry")]
public partial class LogEntry
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string WhatLearned { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Difficulties { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string KeyTakeaways { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("LogEntries")]
    public virtual TblUser User { get; set; } = null!;

    [ForeignKey("LogEntryId")]
    [InverseProperty("LogEntries")]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
