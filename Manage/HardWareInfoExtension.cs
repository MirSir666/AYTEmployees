using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage
{
    public static class HardWareInfoExtension
    {
        public static IServiceCollection UseHardWareInfo(this IServiceCollection builder)
        {
            builder.AddSingleton<IHardWareInfo, HardWareInfo>();

            return builder;
        }
    }
}
