using EmailMessaging.Common.Data.Models;
using System;
using System.Text;

namespace WebAPI.Models.Messages
{
    public class ConfirmAccountMessage : IEmailMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; } = "Confirm your account";
        public string Body { get; set; }

        public ConfirmAccountMessage(string to)
        {
            To = to;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder
                .Append("<html>")
                .Append("body")
                .Append("<h1>Hello!</h1>")
                .Append("<h2>You have just registered an account</h2>")
                .Append("<h3>Follow the link below to confirm your account:</h3>")
                .Append("<a href='google.com'>google.com</<a>")
                .Append("</body>")
                .Append("<html>");

           Body = stringBuilder.ToString(); 



        }
    }
}