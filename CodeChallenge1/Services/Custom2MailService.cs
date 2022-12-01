namespace CodeChallenge1.Services
{
    public class Custom2MailService:IMailService
    {
        private string _mailTo = "admin@company.com";
        private string _mailFrom = "noreplay@company.com";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, {nameof(Custom2MailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message:{message}");
        }
    }
}
