using System.Threading.Tasks;

namespace EmailSender.Smtp.Core.Sample
{
    public class App
    {
        private IEmailSender _emailSender;
        public App(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task RunApp()
        {
            var name = "@thecoderefiner";
            await _emailSender.SendEmailAsync("bioyeneye@gmail.com", $"Test Smtp", $"<p>Hello {name}</p>");
        }
    }
}