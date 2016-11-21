using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SamsonFund.Classes
{
    public class EmailSendingService
    {
        public void SendGmailEmail(string to, string from, string subject, string body, bool isHtml)
        {
            SmtpClient ss = new SmtpClient("smtp.gmail.com", 587);
            ss.EnableSsl = true;
            ss.Timeout = 10000;
            ss.DeliveryMethod = SmtpDeliveryMethod.Network;
            ss.UseDefaultCredentials = false;

            //Password from https://security.google.com/settings/security/apppasswords using 2-step verification
            ss.Credentials = new NetworkCredential("tia.dillman@gmail.com", "jkbymjtieqtzwnya");

            MailMessage mm = new MailMessage(from, to, subject, body);
            mm.IsBodyHtml = isHtml;
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            try
            {
                ss.Send(mm);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}