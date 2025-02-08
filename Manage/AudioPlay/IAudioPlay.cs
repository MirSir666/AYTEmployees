using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage.AudioPlay
{
    public interface IAudioPlay
    {
        void Play(string url);

        void PlayFile(string filePath);

        void PlayMauiFile(string filePath);
    }

    public class AudioPlay : IAudioPlay
    {
        private readonly IAudioFileMonitor audioFileMonitor;
        private readonly IAudioManager audioManager;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IAudioFileReporter audioFileReporter;

        public AudioPlay(IAudioFileMonitor audioFileMonitor, IAudioManager audioManager, IHttpClientFactory httpClientFactory, IAudioFileReporter audioFileReporter)
        {
            this.audioFileMonitor = audioFileMonitor;
            this.audioManager = audioManager;
            this.httpClientFactory = httpClientFactory;
            this.audioFileReporter = audioFileReporter;
            audioFileMonitor.Subscribe(audioFileReporter);
        }

        public async void Play(string filePath)
        {

            try
            {
                using (var client = httpClientFactory.CreateClient())
                {
                    var data = await client.GetByteArrayAsync(filePath).ConfigureAwait(true);
                    var stream = new MemoryStream(data);



                    audioFileMonitor.OnNext(audioManager.CreateAsyncPlayer(stream));




                    //var audioPlayer = audioManager.CreateAsyncPlayer(stream);

                    //await audioPlayer.PlayAsync(CancellationToken.None);

                    // stream.Dispose();
                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public void PlayFile(string filePath)
        {
            try
            {
                byte[] data = File.ReadAllBytes(filePath);

                var stream = new MemoryStream(data);
                audioFileMonitor.OnNext(audioManager.CreateAsyncPlayer(stream));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async void PlayMauiFile(string filePath)
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);
       

                //byte[] data = File.ReadAllBytes(filePath);

                //var stream = new MemoryStream(data);
                audioFileMonitor.OnNext(audioManager.CreateAsyncPlayer(stream));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
