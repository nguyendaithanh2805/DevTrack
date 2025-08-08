using System.ComponentModel.DataAnnotations;

namespace DevTrack.DTOs
{
    public class MistakeDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
        public string Description { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "Occurrence count must be a non-negative number")]
        public int OccurrenceCount { get; set; }
    }
}
