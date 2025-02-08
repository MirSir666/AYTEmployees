using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class OrderDetailInfo
    {

        /// <summary>
        /// 点单渠道：00：收银机，01:点钟宝 03:员工App
        /// </summary>
        public string AddChannel { get; set; } = "00";

        /// <summary>
        /// 商品id
        /// </summary>
        public long GoodsId { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 项目价格(分) 划线价
        /// </summary>
        public long? Price { get; set; }
    }
}
