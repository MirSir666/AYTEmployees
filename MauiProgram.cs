using AYTEmployees.Blazor;
using AYTEmployees.HubClient;
using AYTEmployees.Logic;
using AYTEmployees.Manage;
using AYTEmployees.Manage.AudioPlay;
using AYTEmployees.Manage.TTS;
using AYTEmployees.MicroEvent;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace AYTEmployees
{
    public static class MauiProgram
    {
        public static IServiceCollection ServiceCollection;

        public static T GetService<T>()
        {
            var provider = ServiceCollection.BuildServiceProvider();
            return provider.GetService<T>();
        }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.UseHardWareInfo();
            Settings.Init();
            //builder.Services.AddSingleton<AYTService>();
            //builder.Services.AddScoped<ToastService>();
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.UseAudioPlay();
            builder.Services.UseTTS();
            builder.Services.AddHttpClient();
            builder.Services.UseFlurl();
            builder.Services.UseMicroEvent();
            builder.Services.AddSingleton(sp => {
                return new HubConnectionBuilder()
                    .WithUrl($"{Preferences.Get(UserConst.ServiceUrl,"")}")
                    .Build();
            });
            builder.Services.AddScoped<IBasePage, BasePage>();

            builder.Services.AddTransient<IBaseService, BaseService>();
            builder.Services.AddTransient<ILogonService, LogonService>();
            builder.Services.AddTransient<IMyService, MyService>();
            builder.Services.AddTransient<IWorkbenchesService, WorkbenchesService>();
            builder.Services.AddTransient<IAttendanceService, AttendanceService>();
            builder.Services.AddTransient<IAchievementsService, AchievementsService>();
            builder.Services.AddTransient<IMessageService, MessageService>();
            //ITransportHeartBeat
            builder.Services.AddSingleton<RoutesState>();
            builder.Services.AddSingleton<UI>();
            builder.Services.UseHubClient();
            ServiceCollection = builder.Services;
            return builder.Build();
        }
    }


  
}
