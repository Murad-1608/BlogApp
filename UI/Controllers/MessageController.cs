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
            var inbox = messageService.GetReceiverMessage(appuser.Id);
            inbox.Reverse();
            return View(inbox);
        }
        public IActionResult Send()
        {
            TempData["Panel"] = "Send";
            var sendbox = messageService.GetSenderMessage(appuser.Id);
            sendbox.Reverse();
            return View(sendbox);
        }

        public IActionResult ViewMessage(int id)
        {
            var message = messageService.ViewMessage(id);

            return View(message);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MessageModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var receiver = userManager.FindByEmailAsync(model.Email).Result;

            if (receiver == null)
            {
                ModelState.AddModelError(nameof(model.Email), "Bu emaildə istifadəçi yoxdur");
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

            return RedirectToAction("Send".ToString());
        }

        public IActionResult DeleteReceiveAll()
        {
            var inbox = messageService.GetReceiverMessage(appuser.Id);

            for (int i = 0; i < inbox.Count; i++)
            {
                messageService.Delete(inbox[i].Id);
            }

            return RedirectToAction("Index".ToString());
        }
    }
}
