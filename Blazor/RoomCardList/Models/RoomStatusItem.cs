using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Blazor.RoomCardList.Models
{
    public class RoomStatusItem
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
        /// <summary>
        /// 床位集合
        /// </summary>
        public List<BedInfoBo> BedList { get; set; }

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


    public class BedInfoBo
    {
        /// <summary>
        /// 技师工号
        /// </summary>
        public string JobNumber { get; set; }

        /// <summary>
        /// 技师姓名
        /// </summary>
        public string ArtificerName { get; set; }


        /// <summary>
        /// 预计下钟时间
        /// </summary>
        public DateTime? ExpectClockEndTime { get; set; }

        /// <summary>
        /// 剩余分钟
        /// </summary>
        public string MinutesRemaining { get; set; }


        public int? MinutesRemainingInt { get; set; }


        /// <summary>
        /// 任务状态 01.待钟 02.上钟  03.缺技师 99.完成
        /// </summary>
        public string Status { get; set; }


        /// <summary>
        /// 上钟类型: 00：轮钟，01：点钟，02：call钟，03：加钟,04：选钟
        /// </summary>
        public string WorkType { get; set; }

        /// <summary>
        /// 简短上钟类型名称
        /// </summary>
        public string WorkTypeShortName { get; set; }


        /// <summary>
        /// 项目名称 
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 项目开始时间
        /// </summary>

        public DateTime? ProjectStartTime { get; set; }

        /// <summary>
        /// 项目结束时间
        /// </summary>
        public DateTime? ProjectEndTime { get; set; }

        public string OfflineDetailNo { get; set; }
        public int? ProjectDuration { get; set; }

        public long ArtificerSchedulingTasksId { get; set; }
    }
}
