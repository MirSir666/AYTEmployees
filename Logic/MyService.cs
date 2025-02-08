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
    public interface IMyService: IBaseService
    {
        Task<ResultModel<GetTechnicianInfoOutput>> GetTechnicianInfo();
        Task<ResultModel> UpdatePassword( UpdatePasswordDto input);

        Task<ResultModel> Logout();
    }
    public class MyService : BaseService, IMyService
    {
        public MyService(GetHttpClient getHttpClient, IBasePage basePage) : base(getHttpClient, basePage)
        {
        }

        public Task<ResultModel<GetTechnicianInfoOutput>> GetTechnicianInfo()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> UpdatePassword(UpdatePasswordDto input)
        {
            throw new NotImplementedException();
        }
    }
}
