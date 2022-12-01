namespace CodeChallenge1.Services
{
    public class Custom2MailService:IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = String.Empty;

        public Custom2MailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];

        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, {nameof(Custom2MailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message:{message}");
        }
    }
}
