using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Areas.Admin.Models;
using X.PagedList;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.Title = "Kateqoriya";

            var categories = categoryService.GetAll().ToPagedList(page, 4);
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Kateqoriya";

            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new()
                {
                    Name = model.Name,
                    Status = true
                };

                categoryService.Add(category);

                return RedirectToAction("Index", "Category");
            }

            ViewBag.Title = "Kateqoriya";

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            categoryService.Delete(id);

            return RedirectToAction("Index", "Category");
        }
    }
}
