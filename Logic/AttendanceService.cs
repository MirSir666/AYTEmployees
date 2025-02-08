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

    public interface IAttendanceService : IBaseService
    {
        Task<ResultModel> ClockIn(AttendanceClockRecordsInput input);

        Task<ResultModel> ClockOut(AttendanceClockRecordsInput input);

        Task<ResultModel<GetAttendanceStatusOutput>> GetAttendanceStatus(AttendanceClockRecordsInput input);

        Task<ResultModel<List<AttendanceClockRecordsOutput>>> GetAttendanceClockRecords(AttendanceClockRecordsSearch search);
    }
    public class AttendanceService : BaseService, IAttendanceService
    {
        public AttendanceService(GetHttpClient getHttpClient, IBasePage basePage) : base(getHttpClient, basePage)
        {
        }

        public Task<ResultModel> ClockIn(AttendanceClockRecordsInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel> ClockOut(AttendanceClockRecordsInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<List<AttendanceClockRecordsOutput>>> GetAttendanceClockRecords(AttendanceClockRecordsSearch search)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<GetAttendanceStatusOutput>> GetAttendanceStatus(AttendanceClockRecordsInput input)
        {
            throw new NotImplementedException();
        }
    }
}
