using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    [Authorize]
    public class MessageController : BaseController
    {
        private readonly IMessageService messageService;
        public MessageController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMessageService messageService) : base(userManager, signInManager)
        {
            this.messageService = messageService;
        }
        public IActionResult Index()
        {
            TempData["Panel"] = "Index";
            ViewBag.Title = "Mesaj";

            var inbox = messageService.GetReceiverMessage(appuser.Id);
            inbox.Reverse();
            return View(inbox);
        }
        public IActionResult Send()
        {
            TempData["Panel"] = "Send";
            ViewBag.Title = "Mesaj";
            var sendbox = messageService.GetSenderMessage(appuser.Id);
            sendbox.Reverse();
            return View(sendbox);
        }

        public IActionResult ViewReceiveMessage(int id)
        {
            var message = messageService.GetReceiverMessage(appuser.Id).Find(x => x.Id == id);
            ViewBag.Title = "Mesaj";

            return View(message);
        }

        public IActionResult ViewSendMessage(int id)
        {
            var message = messageService.GetSenderMessage(appuser.Id).Find(x => x.Id == id);
            ViewBag.Title = "Mesaj";

            return View(message);
        }


        public IActionResult Add()
        {           

            ViewBag.Title = "Mesaj";

            return View();
        }
        [HttpPost]
        public IActionResult Add(MessageModel model)
        {
            ViewBag.Title = "Mesaj";


            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var receiverEmail = userManager.FindByEmailAsync(model.Email).Result;
            var receiverUserName = userManager.FindByNameAsync(model.Email).Result;

            AppUser receiver = receiverEmail ?? receiverUserName;

            if (receiver == null)
            {
                ModelState.AddModelError(nameof(model.Email), "Belə istifadəçi mövcud deyil");
                return View(model);
            }
            else if (receiver.Email == appuser.Email)
            {
                ModelState.AddModelError(nameof(model.Email), "Özünüzə mesaj ata bilmərsiniz");
                return View(model);
            }
            Message message = new Message();
            message.SenderId = appuser.Id;
            message.ReceiverId = receiver.Id;
            message.Subject = model.Subject;
            message.Content = model.Content;
            message.Status = true;
            messageService.Add(message);
            return RedirectToAction("Send");
        }

        public IActionResult Delete(int id)
        {
            messageService.Delete(id);

            return RedirectToAction(TempData["Panel"].ToString());
        }

        public IActionResult DeleteSendAll()
        {
            var sendbox = messageService.GetSenderMessage(appuser.Id);

            for (int i = 0; i < sendbox.Count; i++)
            {
                messageService.Delete(sendbox[i].Id);
            }

            ViewBag.Title = "Mesaj";
            return RedirectToAction("Send".ToString());
        }

        public IActionResult DeleteReceiveAll()
        {
            var inbox = messageService.GetReceiverMessage(appuser.Id);

            for (int i = 0; i < inbox.Count; i++)
            {
                messageService.Delete(inbox[i].Id);
            }

            ViewBag.Title = "Mesaj";
            return RedirectToAction("Index".ToString());
        }
    }
}
