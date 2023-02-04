using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Ad boş ola bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email boş ola bilməz")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Mövzu boş ola bilməz")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Mesaj boş ola bilməz")]
        public string Message { get; set; }
    }
}
