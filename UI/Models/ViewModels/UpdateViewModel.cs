using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UI.Models.ViewModels
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public int Seen { get; set; }
        [Required(ErrorMessage = "Başlıq boş ola bilməz")]
        [MinLength(4, ErrorMessage = "Başlıq ən az 4 simvol ola bilər")]
        [MaxLength(50, ErrorMessage = "Başlıq ən çox 50 simvol ola bilər")]
        public string Title { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Mövzu boş ola bilməz")]
        [MinLength(35, ErrorMessage = "Mözvu ən az 35 simvol ola bilər")]
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
