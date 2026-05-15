using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Models
{
    public class ImageItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }
}