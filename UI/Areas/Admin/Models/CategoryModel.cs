using System.ComponentModel.DataAnnotations;

namespace UI.Areas.Admin.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage ="Kateqoriyanı qeyd edin")]
        public string Name { get; set; }
    }
}
