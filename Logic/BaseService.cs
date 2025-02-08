using AYTEmployees.Blazor;
using AYTEmployees.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Logic
{
    public interface IBaseService
    {
        Task<T> Request<T>(string url);

        Task<T> Request<T, Input>(string url, Input input);
    }
    public class BaseService:IBaseService
    {
        public readonly GetHttpClient getHttpClient;
        public readonly IBasePage basePage;



        public BaseService(GetHttpClient getHttpClient, IBasePage basePage)
        {
            this.getHttpClient = getHttpClient;
            this.basePage = basePage;
        }

        public Task<T> Request<T>(string url)
        {
            var http = getHttpClient();
            return http.Post<T>(url);
        }

        public Task<T> Request<T,Input>(string url,Input input)
        {
            var http = getHttpClient();
            return http.Post<T, Input>(url, input);

        }
    }
}
