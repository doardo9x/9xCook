using System.Net;
using System.Net.Mail;

namespace NineXCook.Services;

public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string EmailAddress, string subject, string htmlMessage)
    {
        var mail = "gcook.app@outlook.com";
        var pw = "QV3E4khpZBEcL7K";
        
        var client = new SmtpClient("smtp-mail.outlook.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(mail, pw)
        };

        MailMessage sendMail = new(
            from: mail,
            to: EmailAddress,
            subject,
            htmlMessage
        );
        sendMail.IsBodyHtml = true;

        await client.SendMailAsync(sendMail);
    }
}

