using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetTechnicianProjectsListOutput
    {
        /// <summary>
        ///项目id
        /// </summary>
        public long ProjectId { get; set; }


        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
    }
}
