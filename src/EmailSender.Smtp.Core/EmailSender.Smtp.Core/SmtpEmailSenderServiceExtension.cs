using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSender.Smtp.Core
{
    public static class SmtpEmailSenderServiceExtension
    {
        public static IServiceCollection AddSmtpEmailSender(this IServiceCollection services, IConfiguration configuration)
        {
            var smtpConfiguration = configuration.GetSection(nameof(SmtpEmailSenderConfiguration)).Get<SmtpEmailSenderConfiguration>();
            
            if (smtpConfiguration != null && !string.IsNullOrWhiteSpace(smtpConfiguration.SmtpServer))
            {
                services.AddSingleton(smtpConfiguration);
                services.AddTransient<IEmailSender, DefaultSmtpEmailSender>();
            }
            else
            {
                throw new Exception($"Smtp Configuration is not set in the configuration file, check the format in {nameof(SmtpEmailSenderConfiguration)} class");
            }
            
            return services;
        }
    }
}