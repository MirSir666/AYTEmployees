using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class ModOrderInput
    {
        /// <summary>
        /// 订单详情号
        /// </summary>
        public string? OrderNo { get; set; }
        /// <summary>
        /// 订单详情号
        /// </summary>
        public string? DetailNo { get; set; }


        #region ModOrderDiscountOrOffersInput

        /// <summary>
        /// 整单折扣 1-100
        /// </summary>

        public long? WholeDiscount { get; set; }

        /// <summary>
        /// 整单优惠
        /// </summary>
        public long? WholeOffers { get; set; }
        #endregion


        #region ModOrderPriceInput

        /// <summary>
        /// 价格 --CashierDisPrice
        /// </summary>
        public string? GoodsPrice { get; set; }

        /// <summary>
        /// 是项目还是商品
        /// </summary>
        public bool IsProject { get; set; }
        #endregion


        /// <summary>
        /// 数量
        /// </summary>
        public int? GoodsNumber { get; set; } = 0;

        public long? ProjectId { get; set; } = 0;

        public long? WipeZeroAmt { get; set; } = 0;
        /// <summary>
        /// 是否抹零
        /// </summary>
        public bool IsWipeZero { get; set; }


    }
}
