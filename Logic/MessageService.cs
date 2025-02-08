using AYTEmployees.Blazor;
using AYTEmployees.Manage;
using AYTEmployees.Models;
using AYTEmployees.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Logic
{
    public interface IMessageService : IBaseService
    {
        Task<ResultModel<List<NotificationMessageOutput>>> GetNotificationMessageList(NotificationMessageSerarch serarch);
    }
    public class MessageService : BaseService, IMessageService
    {
        public MessageService(GetHttpClient getHttpClient, IBasePage basePage) : base(getHttpClient, basePage)
        {
        }

        public Task<ResultModel<List<NotificationMessageOutput>>> GetNotificationMessageList(NotificationMessageSerarch serarch)
        {
            throw new NotImplementedException();
        }
    }
}
