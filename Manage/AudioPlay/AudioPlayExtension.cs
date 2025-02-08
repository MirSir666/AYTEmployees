using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage.AudioPlay
{
    public static class AudioPlayExtension
    {
        public static IServiceCollection UseAudioPlay(this IServiceCollection builder)
        {
            builder.AddSingleton<IAudioFileMonitor, AudioFileMonitor>();
            builder.AddSingleton<IAudioFileReporter, AudioFileReporter>();
            builder.AddSingleton<IAudioPlay, AudioPlay>();

            return builder;

        }
    }
}
