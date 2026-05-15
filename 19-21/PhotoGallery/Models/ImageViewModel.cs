using System.ComponentModel.DataAnnotations;

namespace PhotoGallery.Models
{
    public class ImageViewModel
    {
        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "URL изображения обязателен")]
        [Url(ErrorMessage = "Введите корректный URL")]
        public string Url { get; set; }

        // Description — НЕОБЯЗАТЕЛЬНОЕ (убрали [Required])
        [StringLength(200, ErrorMessage = "Описание не должно превышать 200 символов")]
        public string? Description { get; set; }  // знак ? означает "может быть null"
    }
}