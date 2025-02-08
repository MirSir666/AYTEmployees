using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetLineChartDataOutput
    {
        public List<string> Lables { get; set; } = new List<string>();
        /// <summary>
        /// 销售提成数据
        /// </summary>
        public List<decimal> PromoteData { get; set; } = new List<decimal>();

        /// <summary>
        /// 业绩提成数据
        /// </summary>
        public List<decimal> CommissionData { get; set; } = new List<decimal>();
    }
}
