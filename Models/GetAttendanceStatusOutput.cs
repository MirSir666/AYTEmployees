using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetAttendanceStatusOutput
    {
        public AttendanceType? AttendanceType { get; set; }

        public string AttendanceTypeF
        {
            get
            {
                if (AttendanceType > 0)
                    return Enum.GetName(typeof(AttendanceType), AttendanceType);
                return "";
            }
        }

        public string CheckworksTypeF
        {
            get
            {
                if (CheckworksType > 0)
                    return Enum.GetName(typeof(CheckworksType), CheckworksType);
                return "";
            }
        }
        public CheckworksType? CheckworksType { get; set; }

        public bool IsComplete { get; set; }
        public bool IsWifi { get; set; }

        public bool IsLacation { get; set; }

        public DateTime? ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }
    }

    /// <summary>
    /// 打卡类型 1正常2迟到3早退4加班 5未打卡 6补卡
    /// </summary>
    public enum CheckworksType
    {
        正常 = 1,
        迟到 = 2,
        早退 = 3,
        加班 = 4,
        未打卡 = 5,
        补卡 = 6
    }

    /// <summary>
    /// 考勤类型  1上班 2下班
    /// </summary>
    public enum AttendanceType
    {
        上班 = 1,
        下班 = 2
    }
}
