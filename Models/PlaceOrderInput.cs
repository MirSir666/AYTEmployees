using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class PlaceOrderInput
    {
        public long? CardId { get; set; }
        public long? RoomId { get; set; }

        public SaleInfo? SaleInfo { get; set; }


        public List<OrderDetailInfo2> OrderDetails { get; set; } = new List<OrderDetailInfo2>();
    }
    public class OrderDetailInfo2 : OrderDetailInfo
    {

        /// <summary>
        /// 商品类型，00商品，01项目
        /// </summary>
        public string GoodsCategory { get; set; }

        /// <summary>
        /// 性别 1女 2男
        /// </summary>
        public string? Gender { get; set; }
        /// <summary>
        /// 上钟类型: 0：轮钟，1：点钟，2：call钟，3：加钟,4：选钟
        /// </summary>
        public WorkType WorkType { get; set; }

        /// <summary>
        /// 技师id
        /// </summary>
        public long ArtificerId { get; set; }

    }
}
