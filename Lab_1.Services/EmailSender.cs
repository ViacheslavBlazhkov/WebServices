using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Lab_1.Services
{
    public class EmailSender
    {
        public void SendEmail(string email, string subject, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Full Name", "email")); // TODO: change to App Account
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = messageBody };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("email", "app password"); // TODO: change to App Account
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
