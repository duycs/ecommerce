using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Services.ServiceInterfaces
{
    public interface INotificationService
    {
        Task<bool> Notify(Guid userId, string title, string content);
    }
}
