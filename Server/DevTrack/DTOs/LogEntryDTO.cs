using System.ComponentModel.DataAnnotations;

namespace DevTrack.DTOs
{
    public class LogEntryDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "What learned is required")]
        [StringLength(255, ErrorMessage = "What learned cannot exceed 255 characters")]
        public string WhatLearned { get; set; } = null!;

        [Required(ErrorMessage = "Difficulties is required")]
        [StringLength(255, ErrorMessage = "Difficulties cannot exceed 255 characters")]
        public string Difficulties { get; set; } = null!;

        [Required(ErrorMessage = "Key takeaways is required")]
        [StringLength(255, ErrorMessage = "Key takeaways cannot exceed 255 characters")]
        public string KeyTakeaways { get; set; } = null!;
    }
}
