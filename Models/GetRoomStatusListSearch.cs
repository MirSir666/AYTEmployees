using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetRoomStatusListSearch
    {
        /// <summary>
        /// 房间类型
        /// </summary>
        public long RoomTypeId { get; set; }
        /// <summary>
        /// 楼层id
        /// </summary>
        public string? Floor { get; set; }
        /// <summary>
        /// 房间状态
        /// </summary>
        public int? Status { get; set; } = 0;
        /// <summary>
        /// 是否联房
        /// </summary>
        public bool IsUnitedRoom { get; set; }

        /// <summary>
        /// 房间类型集合
        /// </summary>
        public List<long> RoomTypeList { get; set; } = new List<long>();
        /// <summary>
        /// 房间状态集合
        /// </summary>
        public List<int> StatusList { get; set; } = new List<int>();
    }
}
