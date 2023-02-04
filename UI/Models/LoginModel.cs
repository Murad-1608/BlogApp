using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "İstifadəçi adı boş ola bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parol boş ola bilməz")]
        public string Password { get; set; }
    }
}
