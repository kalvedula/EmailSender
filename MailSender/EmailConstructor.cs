using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace EmailCalendarsClient.MailSender
{
    public class EmailConstructor
    {
        BodyBuilder builder = new BodyBuilder();
        private static readonly string SenderName = ConfigurationManager.AppSettings["senderName"];
        private static readonly string SenderEmail = ConfigurationManager.AppSettings["senderEmail"];
        public MimeMessage CreateStandardEmail(string recipient, string header, string body)
        {
            var message = new MimeMessage
            {
                Subject = header,
                
            };
            builder.TextBody = body;
            message.Body = builder.ToMessageBody();
            message.To.Add(new MailboxAddress("", recipient));
            message.From.Add(new MailboxAddress(SenderName, SenderEmail));
            return message;
        }

        public MimeMessage CreateHTMLEmail(string recipient, string header, string body)
        {
            var body1 = new BodyBuilder();
            var message = new MimeMessage
            {
                Subject = header,

            };
            builder.HtmlBody = body;
            message.Body = builder.ToMessageBody();
            message.To.Add(new MailboxAddress("", recipient));
            message.From.Add(new MailboxAddress(SenderName, SenderEmail));
            return message;
        }

        public void AddAttachment(byte[] rawData, string filePath)
        {
            builder.Attachments.Add(filePath, rawData);
            
        }

        public void ClearAttachments()
        {
            builder.Attachments.Clear();
        }

        static public byte[] EncodeTobase64Bytes(byte[] rawData)
        {
            string base64String = System.Convert.ToBase64String(rawData);
            var returnValue = Convert.FromBase64String(base64String);
            return returnValue;
        }
    }
}
