using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetProjectListSearch
    {
        /// <summary>
        /// 项目类型Id
        /// </summary>
        public long? ProjectTypeId { get; set; }

        /// <summary>
        /// 技师id
        /// </summary>
        public long? ArtificerId { get; set; }

        public int CouponId { get; set; }

        /// <summary>
        /// 项目类型 00主项，01副项
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// 1 商品 2 项目
        /// </summary>
        public string DetailType { get; set; }
        /// <summary>
        /// 项目id集合
        /// </summary>

        public List<long> ProjectIds { get; set; } = new List<long>();
    }
}
