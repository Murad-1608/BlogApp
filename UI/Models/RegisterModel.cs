using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="İstifadəçi adı boş ola bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad və soyad boş ola bilməz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email boş ola bilməz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parol boş ola bilməz")]
        [MinLength(6, ErrorMessage = "Ən az 6 simvol ola bilər")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Nömrə boş ola bilməz")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Şəkil boş ola bilməz")]
        public IFormFile Image { get; set; }
    }
}
