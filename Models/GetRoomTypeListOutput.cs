using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetRoomTypeListOutput
    {
        /// <summary>
        /// id
        /// </summary>
        public long RoomTypeId { get; set; }

        /// <summary>
        /// 房间类型
        /// </summary>
        public string RoomType { get; set; }

    }
}
