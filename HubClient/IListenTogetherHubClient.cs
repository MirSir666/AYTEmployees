
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AYTEmployees.Manage;
using AYTEmployees.MicroEvent;
using AYTEmployees.Manage.TTS;
using AYTEmployees.Manage.AudioPlay;


namespace AYTEmployees.HubClient
{
    public interface IListenTogetherHubClient
    {
        /// <summary>
        /// 重连
        /// </summary>
        /// <param name="url"></param>
        void Reconnect(string url = null);
        void SetVal(string url);
        Task Initialize();
    }

    public class ListenTogetherHubClient : IAsyncDisposable, IListenTogetherHubClient
    {

        

        private bool _initialized = false;
        private HubConnection connection;
        private string url;
     

        public void SetVal(string url)
        {

            // var url = $"{Preferences.Get(UserConst.ServiceUrl, "")}自定义"
            this.url = url+ "自定义";
        }

        public async Task Initialize()
        {
            if (!_initialized)
            {

                try
                {
                    //var aurl=new UriBuilder(url);
                    //var status = await NetScannerTool.CheckIpStatus(aurl.Host);
                    //if (status.bit)
                    {
                        //var roomNo = Settings.GetObj<string>(UserConst.RoomNo);
                        //var roomId = Settings.GetObj<string>(UserConst.RoomId);

                        var connection = new HubConnectionBuilder()
                                 .WithUrl(url, options =>
                                 {
              
                                     options.Headers.Add("Ip", Utility.GetLocalIPAddress());
                                     options.Headers.Add("Authorization", "Bearer " + Preferences.Get(UserConst.Token, default(string)));
            
                                 })
                                //.WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.Zero, TimeSpan.FromSeconds(10) })
                                .Build();
                       // connection.KeepAliveInterval = TimeSpan.FromSeconds(60);
                        // await  hubConnection.StopAsync();
                        // hubConnection.Remove("SendChangeArtificerStatusMessage");
                        // hubConnection.Remove("SendArtificeWaitingStatusMessage");




                        connection.Closed += async (exception) =>
                        {
                            do
                            {
                                try
                                {
                                    await connection.StartAsync();
                                }
                                catch (Exception ex)
                                {
                                    await Task.Delay(1000);
                                }

                            } while (!(connection.State == HubConnectionState.Connected));

                        };

                        //connection.On<long, int>("SendChangeArtificerStatusMessage", (roomId, status) =>
                        //{
                        //    var eventAggregator = MauiProgram.GetService<IEventAggregator>();
                        //    eventAggregator.PublishAll(status, UserConst.ChangeRoomHandler);
                        //});

                        //connection.On<string,long>("SendOrderDetailChangMessage", (oid,roomId) =>
                        //{
                        //    var eventAggregator = MauiProgram.GetService<IEventAggregator>();
                        //    eventAggregator.PublishAll("",UserConst.UpdateOrderListHandler);
                        //});


                        connection.On<long>("SendChangeArtificerStatusMessage", id =>
                        {

                            var eventAggregator = MauiProgram.GetService<IEventAggregator>();

                            eventAggregator.PublishAll("", UserConst.SendChangeArtificerStatusMessage);
                            // InitEmployeesInfo();
                            // InitData();
                        });


                        var  tts= MauiProgram.GetService<ITTSEngine>();
                        connection.On<string>("SendArtificeWaitingStatusMessage", meg =>
                        {
                            Task.Run(() => {
                                tts.Speak(meg);
                            });
                            
     ;
                        });
                        var audioPlay = MauiProgram.GetService<IAudioPlay>();
                        connection.On<string>("SendNotificationMessageArtificer", meg =>
                        {
                            var eventAggregator = MauiProgram.GetService<IEventAggregator>();

                            eventAggregator.PublishAll("", UserConst.SendNotificationMessageArtificer);


                            Task.Run(() => {
                                audioPlay.PlayMauiFile("tongzhi.mp3");
                            });

                          

                        });

                        //SendNotificationMessageArtificer


                        //SendOrderDetailChangMessage

                        //connection.On("SendChangeArtificerStatusMessage", () =>
                        //{
                        //    uiContext.Post(state =>
                        //    {
                        //        roomPlaPage.RoomViewQuery();
                        //        // roomPlaPage.TechnicianViewQuery();

                        //    }, null);
                        //    technicianRoomContext.Clients.All.SendChangeArtificerStatusMessage();
                        //});

                        //connection.On("SendChangeGoodsCountMessage", () =>
                        //{
                        //    uiContext.Post(state =>
                        //    {
                        //        uiTransfer.Send("Message.Change", "");
                        //        audioPlay.Play("通知.mp3");
                        //    }, null);
                        //});


                        //connection.On<string>("SendArtificeWaitingStatusMessage", meg =>
                        //{
                        //    technicianRoomContext.Clients.All.SendArtificeWaitingStatusMessage(meg);
                        //});



                        //connection.On<List<string>>("SendReserveAdvanceNoticeMessage", (message) =>
                        //{
                        //    uiContext.Post(state =>
                        //    {
                        //        uiTransfer.Send("reserva.Message", message);
                        //    }, null);
                        //});

                        await connection.StartAsync();
                    }

                   
                }
                catch (Exception ex)
                {
                    //await Task.Delay(TimeSpan.FromSeconds(30)).ConfigureAwait(false);
                    //await Initialize().ConfigureAwait(false);


                }


                _initialized = true;
            }
        }


        public async ValueTask DisposeAsync()
        {
            if (connection != null)
            {
                await connection.DisposeAsync();
                _initialized = false;
            }
        }


        public void Reconnect(string url = null)
        {
            if (url != null)
                SetVal(url);
            _initialized = false;
            Initialize();
        }
    }
}
