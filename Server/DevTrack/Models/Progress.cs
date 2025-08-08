using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

[Table("Progress")]
public partial class Progress
{
    [Key]
    public int Id { get; set; }

    public int Percentage { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Progress")]
    public virtual TblUser IdNavigation { get; set; } = null!;
}
