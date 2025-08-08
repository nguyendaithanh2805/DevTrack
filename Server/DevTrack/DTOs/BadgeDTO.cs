using System.ComponentModel.DataAnnotations;

namespace DevTrack.DTOs
{
    public class BadgeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Icon is required")]
        [StringLength(255, ErrorMessage = "Icon cannot exceed 255 characters")]
        public string Icon { get; set; } = null!;
    }
}
