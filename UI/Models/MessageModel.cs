using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class MessageModel
    {
        [Required(ErrorMessage = "Email qeyd edin")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mövzu qeyd edin")]
        [MaxLength(60, ErrorMessage = "Ən çox 60 simvol ola bilər")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Mesaj yazın")]
        public string Content { get; set; }

        public IFormFile? File { get; set; }
    }
}
