using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetRoomStatusListOutput
    {
        /// <summary>
        /// 房间id
        /// </summary>
        public long RoomId { get; set; }

        /// <summary>
        /// 房间编号
        /// </summary>
        public string RoomNum { get; set; }

        /// <summary>
        /// 床位数
        /// </summary>
        public string BedNum { get; set; }
        ///// <summary>
        ///// 床位集合
        ///// </summary>
        //public List<BedInfoBo> BedList { get; set; }

        /// <summary>
        /// 是否有留言
        /// </summary>
        public bool IsLeaveWord { get; set; }

        /// <summary>
        /// 是否是虚拟房，1是，0否
        /// </summary>
        public string IsVirtual { get; set; }

        /// <summary>
        /// 连房id
        /// </summary>
        public long ConnectRoomRelationshipsId { get; set; }


        /// <summary>
        /// 连房编号
        /// </summary>
        public int SortNo { get; set; }


        /// <summary>
        /// 房间状态 1.空房 2.开房 3.预约 4.上钟中 5.待结账 6.休息 7.清房 8.维修 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 总价格
        /// </summary>
        public long TotalPrice { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }


        public string TotalPriceF { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public string ReserveTime { get; set; }


    }

}
