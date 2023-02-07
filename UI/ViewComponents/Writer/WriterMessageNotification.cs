using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Writer
{
    public class WriterMessageNotification : BaseViewComponent
    {
        private readonly IMessageService messageService;
        public WriterMessageNotification(IMessageService messageService, UserManager<AppUser> userManager) : base(userManager)
        {
            this.messageService = messageService;
        }

        public override IViewComponentResult Invoke()
        {
            var AllMessages = messageService.GetReceiverMessage(appUser.Id);

            ViewBag.MessagesCount = AllMessages.Count();

            var messages = AllMessages.TakeLast(3).Reverse().ToList();

            return View(messages);
        }
    }
}
