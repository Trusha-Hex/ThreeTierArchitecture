using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeTierApp.Core.Services
{
    public interface ITaskNotificationService
    {
        Task<bool> SendEmailNotificationAsync(List<string> recipientEmails, string subject, string body);
    }
}
