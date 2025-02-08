using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage.AudioPlay
{
    public interface IAudioFileReporter : IObserver<AsyncAudioPlayer>
    {

    }

    public class AudioFileReporter : IAudioFileReporter //: IObserver<AsyncAudioPlayer>
    {
        private readonly List<IDisposable> _subscriptions = new List<IDisposable>();
        // private WaveOutEvent outputDevice;
        public AudioFileReporter()
        {
            //outputDevice = new WaveOutEvent();

        }

        private static volatile bool _IsPlaying = false;


        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {
            //Log.Error("AudioFile 播放异常:{@error}", error);
        }
        public async void OnNext(AsyncAudioPlayer value)
        {
            try
            {
                while (_IsPlaying)
                {
                    await Task.Delay(100).ConfigureAwait(false);
                }
                _IsPlaying = true;
            

                var dtask = Task.Delay(5000);
                var task = value.PlayAsync(CancellationToken.None);
                var wtask= await Task.WhenAny(task,dtask).ConfigureAwait(false);

                OnCompleted();
                _IsPlaying = false;

                lock (_subscriptions)
                {
                    _subscriptions.Add(value);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            lock (_subscriptions)
            {
                foreach (var subscription in _subscriptions)
                {
                    subscription.Dispose();
                }
            }

            //  outputDevice.Dispose();
        }
    }
}
