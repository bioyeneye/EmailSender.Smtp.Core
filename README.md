# EmailSender.Smtp.Core
Email sender for .Net Projects with service extension and configuration 

[![NuGet](https://img.shields.io/nuget/dt/EmailSender.Smtp.Core.svg)](https://www.nuget.org/packages/EmailSender.Smtp.Core) 
[![NuGet](https://img.shields.io/nuget/vpre/EmailSender.Smtp.Core.svg)](https://www.nuget.org/packages/EmailSender.Smtp.Core)
[![license](https://img.shields.io/github/license/bioyeneye/EmailSender.Smtp.Core.svg)](https://github.com/bioyeneye/EmailSender.Smtp.Core/blob/master/LICENSE)



### Install with nuget

```
Install-Package EmailSender.Smtp.Core
```

### Install with .NET CLI
```
dotnet add package EmailSender.Smtp.Core
```

## How to use

### Setup - Add configuration in appsettings.json or other 

```json
{
  "SmtpEmailSenderConfiguration": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SmtpUsername": "donotreply@project.com",
    "SmtpPassword": "<secret>",
    "FromName": "Project Team",
    "FromAddress": "donotreply@project.com",
    "SendEmail": false,
    "UseSsl": true
  }
}

```

#### Setup - Add configuration in startup 


```csharp

public IConfiguration Configuration { get; }

public Startup(IConfiguration configuration)
{
    Configuration = configuration;
}

public void ConfigureServices(IServiceCollection services)
{
    //Add other stuffs
    ...
    
    // Add SmtpEmailSender
    services..AddSmtpEmailSender(Configuration);
    
    //Add other stuffs
    ...
}

```

#### Usage

```csharp
public class App
{
    private IEmailSender _emailSender;
    public App(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task SendEmail()
    {
        var name = "@thecoderefiner";
        await _emailSender.SendEmailAsync("simisola.oyeneye@gmail.com", $"Test Smtp", $"<p>Hello {name}</p>");
    }
}
```

