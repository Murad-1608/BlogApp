using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper
{
    public static class PasswordResetHelper
    {
        public static void PasswordResetSendEmail(string link)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtpClient = new SmtpClient();

            mail.From = new MailAddress("BlogSite.az");
            mail.To.Add("murad.yunus.2017@mail.ru");

            mail.Subject = "www.BlogSite.az::Reset Password";
            mail.Body = "<h2>Click to change your password</h2><hr/>";
            mail.Body += $"<a> href='{link}'>Password update</a>";
            mail.IsBodyHtml = true;
            smtpClient.Port = 587;
            //smtpClient.Credentials = new System.Net.NetworkCredential("murad.yunus.2017@gmail.com", "ayicik123");

            smtpClient.Send(mail);
        }
    }
}
