using System.ComponentModel.DataAnnotations;

namespace DevTrack.DTOs
{
    public class AnalyticDTO
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total hours must be a non-negative number")]
        public double TotalHours { get; set; }

        [Required(ErrorMessage = "Most productive time is required")]
        [StringLength(100, ErrorMessage = "Most productive time cannot exceed 100 characters")]
        public string MostProductiveTime { get; set; } = null!;

        [Required(ErrorMessage = "Progress trend is required")]
        [StringLength(100, ErrorMessage = "Progress trend cannot exceed 100 characters")]
        public string ProgressTrend { get; set; } = null!;
    }
}
