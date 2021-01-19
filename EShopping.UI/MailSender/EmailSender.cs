using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EShopping.UI.MailSender
{
    public class EmailSender : IEmailSender
    {
        private const string SendGridKey = "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";
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(SendGridKey , subject, htmlMessage,email);
        }



        private Task Execute(string sendGridKey, string subject, string htmlMessage, string email)
        {
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("samt51.m@icloud.com", "Alışveriş"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage,

            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
