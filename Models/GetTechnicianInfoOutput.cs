using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetTechnicianInfoOutput
    {

        /// <summary>
        /// 任务状态 01.待钟 02.上钟  03.缺技师 99.完成
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 技师id 主键
        /// </summary>

        public long ArtificerId { get; set; }

        /// <summary>
        /// 项目id 
        /// </summary>
        public long ProjectId { get; set; }

        /// <summary>
        /// 技师工号
        /// </summary>
        public string JobNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 技师姓名
        /// </summary>

        public string ArtificerName { get; set; }

        /// <summary>
        ///     555号技师高级足浴还剩/已过56分
        /// </summary>
        public string Remainder { get; set; }
    }
}
