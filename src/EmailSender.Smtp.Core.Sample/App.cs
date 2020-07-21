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

        }
    }
}