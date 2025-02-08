using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class AttendanceClockRecordsOutput
    {

        public int Id { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>

        public long ArtificerId { get; set; }


        public string ArtificerName { get; set; }

        /// <summary>
        /// 打卡时间
        /// </summary>

        public DateTime ClockTime { get; set; }


        public string ClockTimeF { get; set; }
        public string DateF{ get; set; }


        /// <summary>
        /// 打卡类型 1正常2迟到3早退4加班 5未打卡
        /// </summary>

        public int CheckworksType { get; set; }


        public string CheckworksTypeF{ get; set; }


        /// <summary>
        /// 考勤类型  1上班 2下班
        /// </summary>

        public int AttendanceType { get; set; }

        public string AttendanceTypeF { get; set; }


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
