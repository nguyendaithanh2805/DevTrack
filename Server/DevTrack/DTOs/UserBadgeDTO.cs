using System.ComponentModel.DataAnnotations;

namespace DevTrack.DTOs
{
    public class UserBadgeDTO
    {
        public int UserId { get; set; }

        public int BadgeId { get; set; }

        [Required(ErrorMessage = "Earned date is required")]
        public DateTime EarnedDate { get; set; }
    }
}
