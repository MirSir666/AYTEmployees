
using AYTEmployees.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Manage
{
    public static class FlurlHttpExtension
    {
        public static IServiceCollection UseFlurl(this IServiceCollection builder)
        {
            //DefaultFlurlClientFactory
            //builder.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();


            //var serviceProvider = builder.BuildServiceProvider();
            //<IFlurlClientFactory>

            //#if (!DEBUG)
            //            flurlClient.Settings = new ClientFlurlHttpSettings()
            //            {
            //                Timeout = TimeSpan.FromSeconds(15),
            //            };
            //#endif

            //flurlClient.WithHeader
            //builder.AddTransient<IFlurlClient>(serviceProvider => {

            //    //var flurlClientFactory = serviceProvider.GetRequiredService<IFlurlClientFactory>();
            //    //var flurlClient = builder.Resolve<IFlurlClient>();

            //    var handler = new HttpClientHandler();
            //    handler.UseCookies = false;
            //    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            //    var httpCli = new HttpClient(handler);
            //   // var flurlCli = new FlurlClient(httpCli);

            //    var flurlClient = new FlurlClient(httpCli);//flurlClientFactory.Get($"http://{Settings.GetServiceUrl()}/api");// var flurlClient = flurlClientFactory.Get(UrlConfig.WebApiUrl);
            //    flurlClient.BaseUrl = $"http://{Settings.GetServiceUrl()}/api";
            //    var hardWareInfo = serviceProvider.GetRequiredService<IHardWareInfo>();
            //    var appsn = hardWareInfo.GetAppSn();
            //    flurlClient.Headers.Add("AppSN", appsn);
            //    flurlClient.Headers.Add("ClientType", "5");
            //    flurlClient.Headers.Add("Ip", Utility.GetLocalIPAddress());

            //    return flurlClient;

            //});
            //builder.Use(flurlClient);
            //GetHttpClient

            builder.AddTransient<GetHttpClient>(serviceProvider =>()=>
            {

                //var flurlClientFactory = serviceProvider.GetRequiredService<IFlurlClientFactory>();
                //var flurlClient = builder.Resolve<IFlurlClient>();

                var handler = new HttpClientHandler();
                handler.UseCookies = false;
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
               
                var httpClient = new HttpClient(handler);
                
                httpClient.BaseAddress = new Uri($"{Preferences.Get(UserConst.ServiceUrl, default(string))}api/app/employees/");
                var hardWareInfo = serviceProvider.GetRequiredService<IHardWareInfo>();
                var appsn = hardWareInfo.GetAppSn();
                httpClient.DefaultRequestHeaders.Add("AppSN", appsn);
                httpClient.DefaultRequestHeaders.Add("ClientType", "7");
          
                httpClient.DefaultRequestHeaders.Add("Ip", Utility.GetLocalIPAddress());

                var token = Preferences.Get(UserConst.Token, default(string));
                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var tenantId = Preferences.Get(UserConst.TenantId, default(string));
                if (!string.IsNullOrEmpty(tenantId))
                {
                    httpClient.DefaultRequestHeaders.Add("__tenant", tenantId);
                }


                httpClient.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                // var flurlCli = new FlurlClient(httpCli);

                //var flurlClient = new FlurlClient(httpCli);//flurlClientFactory.Get($"http://{Settings.GetServiceUrl()}/api");// var flurlClient = flurlClientFactory.Get(UrlConfig.WebApiUrl);
                //flurlClient.BaseUrl = $"http://{Settings.GetServiceUrl()}/api";
                //var hardWareInfo = serviceProvider.GetRequiredService<IHardWareInfo>();
                //var appsn = hardWareInfo.GetAppSn();
                //flurlClient.Headers.Add("AppSN", appsn);
                //flurlClient.Headers.Add("ClientType", "5");
                //flurlClient.Headers.Add("Ip", Utility.GetLocalIPAddress());

                return httpClient;

            });

            return builder;
        }


      
    }

    public delegate HttpClient GetHttpClient();
}
