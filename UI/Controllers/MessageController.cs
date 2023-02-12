using Business.Abstract;
using Business.Helper;
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

            else
            {
                Message message = new Message();

                if (model.File != null)
                {
                    message.File = SystemIOOperations.AddPhoto(model.File, "Files");
                }

                message.SenderId = appuser.Id;
                message.ReceiverId = receiver.Id;
                message.Subject = model.Subject;
                message.Content = model.Content;
                message.Status = true;
                messageService.Add(message);
                return RedirectToAction("Send");
            }

        }

        public IActionResult Reply(int id)
        {
            MessageModel model = new MessageModel()
            {
                Email = userManager.FindByIdAsync(id.ToString()).Result.Email
            };

            return View(model);
        }


        public IActionResult Delete(int id)
        {
            var message = messageService.GetByIdAll(id);

            if (message.File != null)
            {
                SystemIOOperations.DeletePhoto("Files", message.File);
            }

            messageService.Delete(id);



            return RedirectToAction(TempData["Panel"].ToString());
        }

        public IActionResult DeleteSendAll()
        {
            var sendbox = messageService.GetSenderMessage(appuser.Id);

            for (int i = 0; i < sendbox.Count; i++)
            {
                messageService.Delete(sendbox[i].Id);

                if (sendbox[i].File != null)
                {
                    SystemIOOperations.DeletePhoto("Files", sendbox[i].File);
                }
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

                if (inbox[i].File != null)
                {
                    SystemIOOperations.DeletePhoto("Files", inbox[i].File);
                }
            }

            ViewBag.Title = "Mesaj";
            return RedirectToAction("Index".ToString());
        }


        public async Task<IActionResult> DownloadFile(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Files", filePath);
            var memory = new MemoryStream();

            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {

                    await stream.CopyToAsync(memory);
                }

            }
            catch (Exception)
            {
            }

            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }
    }
}
