using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class AttendanceClockRecordsInput
    {
        //clock 打卡时间  

        public int Id { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>

        public long ArtificerId { get; set; }


        /// <summary>
        /// 打卡时间
        /// </summary>

        public DateTime ClockTime { get; set; }

        /// <summary>
        /// 打卡类型 1正常2迟到3早退4加班 5未打卡 6补卡
        /// </summary>

        public int CheckworksType { get; set; }


        /// <summary>
        /// 考勤类型  1上班 2下班
        /// </summary>

        public int AttendanceType { get; set; }

        /// <summary>
        /// 经度
        /// </summary>

        public double? Latitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>

        public double? Longitude { get; set; }

        /// <summary>
        /// 路由器地址
        /// </summary>

        public string? MACAddress { get; set; }
    }
}
