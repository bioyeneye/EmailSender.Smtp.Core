using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EmailSender.Smtp.Core
{
    public class DefaultSmtpEmailSender : IEmailSender
    {
        private readonly ILogger<DefaultSmtpEmailSender> _logger;
        private readonly SmtpEmailSenderConfiguration _configuration;
        private readonly SmtpClient _client;

        public DefaultSmtpEmailSender(SmtpEmailSenderConfiguration configuration, ILogger<DefaultSmtpEmailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _client = new SmtpClient
            {
                Host = _configuration.SmtpServer,
                Port = _configuration.SmtpPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = _configuration.UseSsl
            };
            if (!string.IsNullOrEmpty(_configuration.SmtpPassword))
                _client.Credentials = new System.Net.NetworkCredential(_configuration.SmtpUsername, _configuration.SmtpPassword);
            else
                _client.UseDefaultCredentials = true;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation($"Sending email: {email}, subject: {subject}, message: {htmlMessage}");
            try
            {
                var mail = new MailMessage(_configuration.SmtpUsername, email);
                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = htmlMessage;
                _client.Send(mail);
                _logger.LogInformation($"Email: {email}, subject: {subject}, message: {htmlMessage} successfully sent");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception {ex} during sending email: {email}, subject: {subject}");
                throw;
            }
        }
    }
}