using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class ChangeArtificerInput : NextTechnicianSearch
    {
        /// <summary>
        /// 订单详情号
        /// </summary>
        public string? DetailNo { get; set; }
        /// <summary>
        /// 技师Id
        /// </summary>
        public long OldArtificerId { get; set; }

        public long NewArtificerId { get; set; }

        public string? WorkType { get; set; }
        /// <summary>
        /// 是否圈牌
        /// </summary>
        public bool IsBreak { get; set; }
    }
}
