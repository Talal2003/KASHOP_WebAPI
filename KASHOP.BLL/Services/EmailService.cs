using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace KASHOP.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            var client = new SmtpClient(_config["EmailSettings:Host"], int.Parse(_config["EmailSettings:Port"]))
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_config["EmailSettings:Email"], _config["EmailSettings:Password"])
            };

            var message = new MailMessage(_config["EmailSettings:Email"], to, subject, htmlBody)
            {
                IsBodyHtml = true
            };

            await client.SendMailAsync(message);
        }
    }
}