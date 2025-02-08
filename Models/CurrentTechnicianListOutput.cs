
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class CurrentTechnicianListOutput
    {
        /// <summary>
        /// 技师id
        /// </summary>
        public long ArtificerId { get; set; }

        /// <summary>
        /// 技师工号
        /// </summary>
        public string JobNumber { get; set; }

        /// <summary>
        /// 技师姓名
        /// </summary>
        public string ArtificerName { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>

        public DateTime? JoinTime { get; set; }


        /// <summary>
        /// 技师性别 1：女  2：男
        /// </summary>
        public string Sex { get; set; }


        public string SexF { get; set; }


        /// <summary>
        /// 班次，关联t_fkl_classes.classes_id
        /// </summary>
        public long ClassesId { get; set; }
        /// <summary>
        /// 班次名称
        /// </summary>
        public string ClassesName { get; set; }

        public string GroupName { get; set; }

        /// <summary>
        /// 简短班次名称
        /// </summary>
        public string ClassesShortName { get; set; }


        /// <summary>
        /// 轮钟数量
        /// </summary>
        public int RotateCount { get; set; }
        /// <summary>
        /// 点钟数量
        /// </summary>
        public int OclockCount { get; set; }
        /// <summary>
        /// 加钟数量
        /// </summary>
        public int AddClockCount { get; set; }

        /// <summary>
        /// 括钟数量
        /// </summary>
        public int CallCount { get; set; }
        /// <summary>
        /// 选钟数量
        /// </summary>
        public int SelectionCount { get; set; }

        public string OfflineDetailNo { get; set; }

        /// <summary>
        /// 统计数量
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 当前上钟类型
        /// </summary>
        public string CurrentWorkType { get; set; }

        /// <summary>
        /// 简短上钟类型名称
        /// </summary>
        public string CurrentWorkTypeShortName { get; set; }
        /// <summary>
        /// 当前项目名称
        /// </summary>
        public string CurrentProjectName { get; set; }

        public long CurrentProjectId { get; set; }

        /// <summary>
        /// 当前排序值
        /// </summary>
        public int CurrentSort { get; set; }


        /// <summary>
        /// 当前项目剩余时间
        /// </summary>
        public double? CurrentProjectTime { get; set; }


        public string CurrentProjectTimeF { get; set; }
        /// <summary>
        /// 技师岗位
        /// </summary>
        public long PostId { get; set; }

        public string PostName { get; set; }

        /// <summary>
        /// 房间编号
        /// </summary>
        public string CurrentRoomNum { get; set; }

        /// <summary>
        /// 起钟时间
        /// </summary>
        public DateTime? CurrentClockStartTime { get; set; }

        /// <summary>
        /// 预计下钟时间
        /// </summary>
        public DateTime? CurrentExpectClockEndTime { get; set; }

        /// <summary>
        /// 上钟状态 01：空闲  02：待钟 03：上钟 04：预约
        /// 05:休假 06:下班 07:圈牌
        /// </summary>
        public string ClockStatus { get; set; }


        /// <summary>
        /// 待钟时间
        /// </summary>
        public DateTime? WaitingClockTime { get; set; }
        public string ClockStatusF { get; set; }


        public string ClockStat
        {
            get {

                return $"轮{RotateCount}点{OclockCount}加{AddClockCount}括{CallCount}选{SelectionCount}";
            
            }

        }
        /// <summary>
        /// 是否是加班
        /// </summary>
        public bool IsOvertime { get; set; }


    }
}
