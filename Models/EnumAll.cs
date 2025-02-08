using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    //public enum ClientType
    //{

    //    主收银台 = 1,
    //    副收银台 = 2,
    //    迎宾台 = 3,
    //    服务台 = 4,
    //    技师房 = 5,
    //    点钟宝 = 6,
    //    技师APP = 7,
    //}
    public enum WorkType
    {
       
        [Description("01")]
        轮 = 1,
        [Description("02")]
        点 = 2,
        [Description("04")]
        括 = 4,
        [Description("03")]
        加 = 3,
        [Description("05")]
        选 = 5
    }

    public enum RoutelinkName
    {
        /// <summary>
        /// 业绩
        /// </summary>
        achievements = 1,
        /// <summary>
        /// 消息
        /// </summary>
        message = 2,
        /// <summary>
        /// 我的
        /// </summary>
        my = 3,
        /// <summary>
        /// 工作台
        /// </summary>
        workbenches = 4

    }
}
