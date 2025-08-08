using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevTrack.Models;

public partial class Analytic
{
    [Key]
    public int Id { get; set; }

    public double TotalHours { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string MostProductiveTime { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ProgressTrend { get; set; } = null!;

    [ForeignKey("Id")]
    [InverseProperty("Analytic")]
    public virtual TblUser IdNavigation { get; set; } = null!;
}
