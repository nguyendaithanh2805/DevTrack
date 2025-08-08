using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

[Table("Badge")]
public partial class Badge
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Icon { get; set; } = null!;

    [InverseProperty("Badge")]
    public virtual ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
}
