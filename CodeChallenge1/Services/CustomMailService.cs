namespace CodeChallenge1.Services
{
    public class CustomMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private  readonly string _mailFrom = String.Empty;

        public CustomMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
            
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, {nameof(CustomMailService)}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message:{message}");
        }


    }
}
