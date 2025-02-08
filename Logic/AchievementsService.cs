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
    public interface IAchievementsService : IBaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ResultModel<GetLineChartDataOutput>> GetLineChartData(PromoteStatisticsSearch search);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<ResultModel<List<GetPromoteDataOutput>>> GetPromoteData(PromoteStatisticsSearch search);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
       Task<ResultModel<List<GetCommissionDataOutput>>> GetCommissionData(PromoteStatisticsSearch search);
    }
    public class AchievementsService : BaseService, IAchievementsService
    {
        public AchievementsService(GetHttpClient getHttpClient, IBasePage basePage) : base(getHttpClient, basePage)
        {
        }

        public Task<ResultModel<List<GetCommissionDataOutput>>> GetCommissionData(PromoteStatisticsSearch search)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<GetLineChartDataOutput>> GetLineChartData(PromoteStatisticsSearch search)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<List<GetPromoteDataOutput>>> GetPromoteData(PromoteStatisticsSearch search)
        {
            throw new NotImplementedException();
        }
    }
}
