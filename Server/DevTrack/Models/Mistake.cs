using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

[Table("Mistake")]
public partial class Mistake
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    public int OccurrenceCount { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Mistakes")]
    public virtual TblUser User { get; set; } = null!;
}
