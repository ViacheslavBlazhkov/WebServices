namespace Lab_1.Services
{
    internal interface IEmailSender
    {
        public void SendEmail(string email, string subject, string messageBody);
    }
}
