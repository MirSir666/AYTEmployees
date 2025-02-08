using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetCommissionDataOutput
    {
        /// <summary>
        /// 提成核算类型 1技师提成 2卡卷销售提成 3商品销售提成  4项目销售提成 5等级购买提成
        /// </summary>
        public int BusType { get; set; }


        public string BusTypeF { get; set; }


        /// <summary>
        /// 商品id 卡项目id 等级Id
        /// </summary> 
        public long BusId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 提成
        /// </summary>
        public decimal? Income { get; set; }



        /// <summary>
        /// 数量
        /// </summary>
        public decimal? Number { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
