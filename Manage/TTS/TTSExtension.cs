using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage.TTS
{
    public static class TTSExtension
    {
        public static IServiceCollection UseTTS(this IServiceCollection builder)
        {
            builder.AddSingleton<ITTSEngine, TTS>();

            return builder;
        }
    }
}
