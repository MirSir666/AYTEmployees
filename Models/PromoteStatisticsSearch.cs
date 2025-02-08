using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class PromoteStatisticsSearch
    {
        /// <summary>
        /// 1今天 2昨天 3本月 4上月
        /// </summary>
        public int Type { get; set; } = 1;

        public long EmployeesId { get; set; }
    }
}
