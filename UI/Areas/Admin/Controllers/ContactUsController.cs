using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactUsController : Controller
    {
        private readonly IContactService contactService;
        public ContactUsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index(int page = 1)
        {
            ViewBag.Title = "Əlaqə";

            var values = contactService.GetAll().ToPagedList(page, 10);

            values.Reverse();

            return View(values);
        }
        public IActionResult MessageDetail(int id)
        {
            ViewBag.Title = "Əlaqə";

            var message = contactService.Get(id);

            return View(message);
        }
    }
}
