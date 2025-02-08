using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models.Base
{
    public class PageCondition
    {
        public PageCondition()
            : this(1, 20)
        { }

        /// <summary>
        /// 初始化一个 指定页索引与页大小的分页查询条件信息类 的新实例
        /// </summary>
        /// <param name="pageIndex"> 页索引 </param>
        /// <param name="pageSize"> 页大小 </param>
        public PageCondition(int pageIndex, int pageSize)
        {

            PageIndex = pageIndex;
            PageSize = pageSize;

        }


        public int PageIndex { get; set; }


        public int PageSize { get; set; }


    }
}
