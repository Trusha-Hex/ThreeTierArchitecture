using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ThreeTierApp.Core.Services
{
    public class TaskNotificationService : ITaskNotificationService
    {
        public async Task<bool> SendEmailNotificationAsync(List<string> recipientEmails, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("notification.hexwireless@gmail.com", "ejuamvaittnzzrgl"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("notification.hexwireless@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false,
                };

                // Add recipient emails to the message
                foreach (var email in recipientEmails)
                {
                    mailMessage.To.Add(email);
                }

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
