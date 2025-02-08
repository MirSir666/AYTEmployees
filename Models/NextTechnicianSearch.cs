using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class NextTechnicianSearch
    {
        //public long DetailNo { get; set; }
        public long ProjectId { get; set; }

        /// <summary>
        /// 是否强换
        /// </summary>
        public bool IsForce { get; set; }

        /// <summary>
        /// 技师性别 1女,2男
        /// </summary>
        public string? Sex { get; set; }

        public int? MinSort { get; set; }

    }
}
