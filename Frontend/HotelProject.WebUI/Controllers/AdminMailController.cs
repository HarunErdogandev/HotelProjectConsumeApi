using HotelProject.WebUI.Models.Mail;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        { 
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("HotelierAdmin", "harunerdgan21@gmail.com");
            mimeMessage.From.Add(mailboxAddress);
            MailboxAddress ToMailboxAdress = new MailboxAddress("User", adminMailViewModel.ReceiverMail);
            mimeMessage.To.Add(ToMailboxAdress);

            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody = adminMailViewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = adminMailViewModel.Subject;

            SmtpClient client = new();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("harunerdgan21@gmail.com", "feta lspu rfkn wvmv");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
