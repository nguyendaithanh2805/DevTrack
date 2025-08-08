using System.ComponentModel.DataAnnotations;

namespace DevTrack.DTOs
{
    public class ProgressDTO
    {
        public int Id { get; set; }

        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        public int Percentage { get; set; }
    }
}
