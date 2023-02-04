using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Category
{
    public class GetCategories : ViewComponent
    {
        private readonly ICategoryService categoryService;
        public GetCategories(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetAll();

            return View(categories);
        }
    }
}
