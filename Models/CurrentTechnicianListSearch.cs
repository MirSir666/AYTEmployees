using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class CurrentTechnicianListSearch
    {

        /// <summary>
        /// 技师工号
        /// </summary>
        public string? JobNumber { get; set; }

        /// <summary>
        /// 技师姓名
        /// </summary>
        public string? ArtificerName { get; set; }

        /// <summary>
        /// 卡内码
        /// </summary>
        public string? CardNumber { get; set; }

        /// <summary>
        /// 技师性别 1女,2男
        /// </summary>
        public string? Sex { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        public long ClassesId { get; set; }

        /// <summary>
        /// 技师是否专职
        /// </summary>
        public bool IsMaster { get; set; } = true;

        /// <summary>
        /// 班组id
        /// </summary>
        public long? GroupId { get; set; }

        public List<long> AitifIds { get; set; } = new List<long>();

        public void AddAitifIds(params long[] aitifIds)
        {
            if (AitifIds.Any(o => o == -1))
                return;

            if (!AitifIds.Any())
                AitifIds = aitifIds.ToList();
            else
                AitifIds = AitifIds.Except(aitifIds).ToList();
        }

        /// <summary>
        /// 技师岗位
        /// </summary>
        public long PostId { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        public long ProjectId { get; set; }

        public List<long> ProjectIds { get; set; } = new List<long>();
        /// <summary>
        /// 技师级别 
        /// </summary>
        public long LevelId { get; set; }

        /// <summary>
        /// 上钟状态 01：空闲  02：待钟 03：上钟 04：预约
        /// 05:休假 06:下班 07:圈牌   
        /// 全部0  上班-1  缺勤 -2 -3可上钟
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 上钟状态 01：空闲  02：待钟 03：上钟 04：预约
        /// </summary>
        public string? ClockStatus { get; set; }


        public int? MinSort { get; set; }

        public bool? IsWorkers { get; set; }


        public List<long> GroupIds { get; set; } = new List<long>();
        public List<long> PostIds { get; set; } = new List<long>();

        public List<string?> ClockStatusList { get; set; } = new List<string?>();





    }
}
