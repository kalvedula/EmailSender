using EmailCalendarsClient.MailSender;
using Microsoft.Identity.Client;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace GraphEmailClient
{
    public partial class MainWindow : Window
    {
        EmailService _service = new EmailService();
        EmailConstructor _emailService = new EmailConstructor();

        public MainWindow()
        {
            InitializeComponent();
        }

        private  void SendEmail(object sender, RoutedEventArgs e)
        {
            var message = _emailService.CreateStandardEmail(EmailRecipientText.Text, 
                EmailHeader.Text, EmailBody.Text);

             _service.SendEmailAsync(message);
            _emailService.ClearAttachments();
        }

        private  void SendHtmlEmail(object sender, RoutedEventArgs e)
        {
            var messageHtml = _emailService.CreateHTMLEmail(EmailRecipientText.Text,
                EmailHeader.Text, EmailBody.Text);

             _service.SendEmailAsync(messageHtml);
            _emailService.ClearAttachments();
        }

        private void AddAttachment(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                byte[] data = File.ReadAllBytes(dlg.FileName);
                _emailService.AddAttachment(data, dlg.FileName);
            }
        }
    }
}
