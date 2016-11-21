using SamsonFund.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SamsonFund.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Why()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SendContactRequest(string name, string phoneNumber, string email, string message)
        {
            EmailSendingService _EmailSendingService = new EmailSendingService();

            string textBody = "<br>Name: " + name + "<br>" +
                "Phone Number: " + phoneNumber + "<br>" +
                "Email: " + email + "<br>" +
                "Message: " + message;

            string emailBody = "<b>Samson Fund received an information request:</b><br>" +
                "<br>Name: " + name + "<br>" +
                "Phone Number: " + phoneNumber + "<br>" +
                "Email: " + email + "<br>" +
                "Message: " + message;

            try
            {
                _EmailSendingService.SendGmailEmail("8014509177@tmomail.net", "tia.dillman@gmail.com", "Samson Fund Information Request", textBody, true);
                _EmailSendingService.SendGmailEmail("tia.dillman@gmail.com", "tia.dillman@gmail.com", "Samson Fund Request", emailBody, true);
            }
            catch (Exception ex)
            {
                return Json(new { Success = "False", responseText = ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Success = true });
        }
    }
}