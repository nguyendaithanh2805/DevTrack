using System.ComponentModel.DataAnnotations;

namespace DevTrack.DTOs
{
    public class ReminderDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(255, ErrorMessage = "Message cannot exceed 255 characters")]
        public string Message { get; set; } = null!;

        [Required(ErrorMessage = "Time is required")]
        public TimeOnly Time { get; set; }
    }
}
