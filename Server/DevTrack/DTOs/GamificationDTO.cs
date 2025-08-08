using System.ComponentModel.DataAnnotations;

namespace DevTrack.DTOs
{
    public class GamificationDTO
    {
        public int Id { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "XP must be a non-negative number")]
        public int Xp { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Level must be at least 1")]
        public int Level { get; set; }
    }
}
