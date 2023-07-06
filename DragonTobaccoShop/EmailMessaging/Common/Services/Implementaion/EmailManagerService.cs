using EmailMessaging.Common.Data.Models;
using EmailMessaging.Common.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace EmailMessaging.Common.Services.Implementaion
{
    public class EmailManagerService : IEmailManagerService
    {
        public void SendEmail(IEmailMessage message)
        {
            var emailMessage = new MailMessage()
            {
                From = new MailAddress(message.From),
                Subject = message.Subject,
                Body = message.Body
            };
            emailMessage.To.Add(new MailAddress(message.To));
            emailMessage.IsBodyHtml = true;

            using var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(message.From, "Wthrudoing07162002"),
                EnableSsl = true
            };

            client.Send(emailMessage);
        }
    }
}