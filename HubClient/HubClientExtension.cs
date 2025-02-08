using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.HubClient
{
    public static class HubClientExtension
    {
        public static IServiceCollection UseHubClient(this IServiceCollection builder)
        {

            builder.AddSingleton<IListenTogetherHubClient, ListenTogetherHubClient>();
            return builder;
        }

        public static void Start()
        {
            var listenTogetherHubClient = MauiProgram.GetService<IListenTogetherHubClient>();
            var url = Preferences.Get(UserConst.ServiceUrl, default(string));
            listenTogetherHubClient.Reconnect(url);
        }
    }
}
