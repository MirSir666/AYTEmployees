using AYTEmployees.Blazor;
using AYTEmployees.Blazor.RoomCardList.Models;
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

    public interface IWorkbenchesService : IBaseService
    {
        Task<ResultModel<CurrentTechnicianListOutput>> GetTechnicianInfo();

        /// <summary>
        ///  换项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ResultModel> ModOrderProjecrInfo(ModOrderInput input);
        /// <summary>
        /// 换技师
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ResultModel> ChangeArtificer(ChangeArtificerInput input);

        Task<ResultModel> AddClock(AddClockInput input);

        Task<ResultModel> Refund(string detailNo);

        Task<List<DictDto>> GetProjectListByArtifierId();
        /// <summary>
        /// 启钟
        /// </summary>
        /// <returns></returns>
        Task<ResultModel> StartWork();
        /// <summary>
        /// 落钟
        /// </summary>
        /// <returns></returns>
        Task<ResultModel> EndWork();

        /// <summary>
        /// 获取房间状态数据
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<List<RoomStatusItem>> GetRoomStatusList(GetRoomStatusListSearch search);


        Task<List<CurrentTechnicianListOutput>> GetCurrentTechnicianList(CurrentTechnicianListSearch search);


        Task<List<GetRoomTypeListOutput>> GetRoomTypeList();

        Task<List<GetRoomStatusOutput>> GetRoomStatusStatistics();

        Task<List<GetTechnicianProjectsListOutput>> GetTechnicianProjectsList();


        Task<List<GetClassesListOutput>> GetClassesList();

        Task<List<DictDto>> GetGroupList();

        Task<List<DictDto>> GetGoodsTypeList(GetGoodsTypeListSearch search);

        Task<ResultModel> PlaceOrder(PlaceOrderInput input);

        Task<List<GetGoodsProjecListOutput>> GetGoodsProjecList(GetProjectListSearch search);

    }
    public class WorkbenchesService : BaseService, IWorkbenchesService
    {
        public WorkbenchesService(GetHttpClient getHttpClient, IBasePage basePage) : base(getHttpClient, basePage)
        {
        }

        public Task<ResultModel> AddClock(AddClockInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> ChangeArtificer(ChangeArtificerInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> EndWork()
        {
            throw new NotImplementedException();
        }

        public Task<List<GetClassesListOutput>> GetClassesList()
        {
            throw new NotImplementedException();
        }

        public Task<List<CurrentTechnicianListOutput>> GetCurrentTechnicianList(CurrentTechnicianListSearch search)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetGoodsProjecListOutput>> GetGoodsProjecList(GetProjectListSearch search)
        {
            throw new NotImplementedException();
        }

        public Task<List<DictDto>> GetGoodsTypeList(GetGoodsTypeListSearch search)
        {
            throw new NotImplementedException();
        }

        public Task<List<DictDto>> GetGroupList()
        {
            throw new NotImplementedException();
        }

        public Task<List<DictDto>> GetProjectListByArtifierId()
        {
            throw new NotImplementedException();
        }

        public Task<List<RoomStatusItem>> GetRoomStatusList(GetRoomStatusListSearch search)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetRoomStatusOutput>> GetRoomStatusStatistics()
        {
            throw new NotImplementedException();
        }

        public Task<List<GetRoomTypeListOutput>> GetRoomTypeList()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<CurrentTechnicianListOutput>> GetTechnicianInfo()
        {
            throw new NotImplementedException();
        }

        public Task<List<GetTechnicianProjectsListOutput>> GetTechnicianProjectsList()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> ModOrderProjecrInfo(ModOrderInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> PlaceOrder(PlaceOrderInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> Refund(string detailNo)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> StartWork()
        {
            throw new NotImplementedException();
        }
    }

    //public interface IWorkbenchesService:IBaseService
    //{

    //}
    //public class WorkbenchesService : BaseService, IWorkbenchesService
    //{
    //    public WorkbenchesService(GetHttpClient getHttpClient, IBasePage basePage) : base(getHttpClient, basePage)
    //    {
    //    }
    //}
}
