using AYTEmployees.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class AttendanceClockRecordsSearch : PageCondition
    {
        public AttendanceClocSearchType? AttendanceClocSearch { get; set; } = AttendanceClocSearchType.今天;

        public long ArtificerId { get; set; }
    }
    public  enum AttendanceClocSearchType
    {
        今天 = 1, 昨天 = 2, 本月 = 3, 上月 = 4
    }
}
