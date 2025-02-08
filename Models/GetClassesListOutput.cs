using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetClassesListOutput
    {
        /// <summary>
        /// 班次id
        /// </summary>
        public long ClassesId { get; set; }


        /// <summary>
        /// 班次名称
        /// </summary>
        public string ClassesName { get; set; }
    }
}
