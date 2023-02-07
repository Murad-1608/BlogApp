using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Email boş ola bilməz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "İstifadəçi adı boş ola bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad və soyad boş ola bilməz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Telefon boş ola bilməz")]
        public string PhoneNumber { get; set; }
        public IFormFile? Image { get; set; }
        public string? CurrentImage { get; set; }
    }
}
