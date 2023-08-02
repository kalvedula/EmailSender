using MailKit.Net.Smtp;
using System.Net.Http;
using System;
using MimeKit;
using System.Configuration;


namespace EmailCalendarsClient.MailSender
{
    public class EmailService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private static readonly string Domain = ConfigurationManager.AppSettings["domain"];
        private static readonly string Username = ConfigurationManager.AppSettings["username"];
        private static readonly string Hash = ConfigurationManager.AppSettings["hash"];
        private static readonly string Port = ConfigurationManager.AppSettings["port"];

        public void SendEmailAsync(MimeMessage message)
        {

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(Domain, int.Parse(Port));

                emailClient.Authenticate(Username, "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");

                emailClient.Send(message);

                emailClient.Disconnect(true);

            }
        }

    }
}
