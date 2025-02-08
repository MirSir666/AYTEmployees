using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage.AudioPlay
{
      public interface IAudioFileMonitor : IObservable<AsyncAudioPlayer>
    {
        void OnNext(AsyncAudioPlayer val);
       
    }
    public class AudioFileMonitor : IAudioFileMonitor
    {
        List<IObserver<AsyncAudioPlayer>> observers;

        public AudioFileMonitor()
        {
            observers = new List<IObserver<AsyncAudioPlayer>>();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<AsyncAudioPlayer>> _observers;
            private IObserver<AsyncAudioPlayer> _observer;

            public Unsubscriber(List<IObserver<AsyncAudioPlayer>> observers, IObserver<AsyncAudioPlayer> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<AsyncAudioPlayer> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }


        public void OnNext(AsyncAudioPlayer val)
        {
            foreach (var observer in observers)
                observer.OnNext(val);
        }
    }
}
