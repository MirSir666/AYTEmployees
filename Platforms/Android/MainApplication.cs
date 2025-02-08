using Android.App;
using Android.Runtime;
using AYTEmployees.WifiTool;

namespace AYTEmployees
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            Platforms.Android.AndroidWifiNetworkService.Init(this);
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
