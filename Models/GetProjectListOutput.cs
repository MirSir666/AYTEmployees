﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class GetProjectListOutput
    {
        /// <summary>
        /// 项目Id
        /// </summary>
        public string ProjectId { get; set; }


        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 项目时长，单位分钟
        /// </summary>
        public int? ProjectDuration { get; set; }

        /// <summary>
        /// 项目价格(分) 划线价
        /// </summary>
        public long? Price { get; set; }


        public string PriceF { get; set; }


    }
}
