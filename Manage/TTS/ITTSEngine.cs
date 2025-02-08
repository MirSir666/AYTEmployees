using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage.TTS
{
    public interface  ITTSEngine
    {
        string Name { get; }

        void Stop();

        void Speak(string text,int index=0);

        byte[] ToFile(string text, int index = 0);
    }
}
