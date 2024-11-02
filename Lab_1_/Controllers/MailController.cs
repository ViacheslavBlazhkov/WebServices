using Lab_1.Services;
using Microsoft.AspNetCore.Mvc;


namespace Lab_1_.Controllers
{
    public class MailController : ControllerBase
    {
        [HttpPost]
        public IActionResult Send()
        {
            EmailSender sender = new EmailSender();
            sender.SendEmail("email", "Subject", "Body"); // TODO: update for requests
            return Ok("Success");
        }
    }
}
