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
    public interface ILogonService: IBaseService
    {
        Task<ResultModel<AytCurrentUser>> GetUserAccount();
        Task<ResultModel<PostLoginOutput>> Login(LoginInputVo input);
    }
    public class LogonService : BaseService, ILogonService
    {
        public LogonService(GetHttpClient getHttpClient, IBasePage basePage) : base(getHttpClient, basePage)
        {
        }

        public Task<ResultModel<AytCurrentUser>> GetUserAccount()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<PostLoginOutput>> Login(LoginInputVo input)
        {
            throw new NotImplementedException();
        }
    }
}
