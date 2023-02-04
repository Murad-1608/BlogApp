using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models.ViewModels
{
    public class BlogViewModel
    {
        public BlogModel BlogModel { get; set; }
        public List<SelectListItem> Categories { get; set; }

    }
}
