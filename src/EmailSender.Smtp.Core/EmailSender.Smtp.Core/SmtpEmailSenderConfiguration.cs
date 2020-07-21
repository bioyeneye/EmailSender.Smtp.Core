namespace EmailSender.Smtp.Core
{
    public class SmtpEmailSenderConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; } = 587; // default smtp port
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public bool UseSsl { get; set; } = true;
        public bool SendEmail { get; set; } = true;
    }
}