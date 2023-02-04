using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new()
                {
                    UserName = model.UserName,
                    Mail = model.Mail,
                    Subject = model.Subject,
                    Message = model.Message,
                    Status = true
                };
                contactService.Add(contact);
                return RedirectToAction("Index","Blog");  
            }
            return View(model);
            
        }
    }
}
