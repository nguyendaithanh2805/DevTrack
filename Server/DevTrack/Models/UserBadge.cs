using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

[PrimaryKey("UserId", "BadgeId")]
[Table("UserBadge")]
public partial class UserBadge
{
    [Key]
    public int UserId { get; set; }

    [Key]
    public int BadgeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EarnedDate { get; set; }

    [ForeignKey("BadgeId")]
    [InverseProperty("UserBadges")]
    public virtual Badge Badge { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserBadges")]
    public virtual TblUser User { get; set; } = null!;
}
