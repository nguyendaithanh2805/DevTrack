using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

[Table("Gamification")]
public partial class Gamification
{
    [Key]
    public int Id { get; set; }

    [Column("XP")]
    public int Xp { get; set; }

    public int Level { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Gamification")]
    public virtual TblUser IdNavigation { get; set; } = null!;
}
