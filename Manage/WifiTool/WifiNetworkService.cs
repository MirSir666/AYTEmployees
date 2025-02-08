using AYTEmployees.WifiTool.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
#if WINDOWS||WINDOWS10_0_19041_0
using Windows.Devices.WiFi;
using Windows.Networking.Connectivity;
using Windows.Networking;
using Windows.Security.Credentials;
using Windows.Devices.Enumeration;
#elif ANDROID
#endif


namespace AYTEmployees.WifiTool
{
    public partial class WifiNetworkService : IWifiNetworkService
    {
        public void Dispose()
        {
           
        }

        public Task<NetworkData> GetNetworkInfo()
        {
#if WINDOWS
            NetworkData data = new NetworkData();
            var profile = NetworkInformation.GetInternetConnectionProfile();
            data.StausId = (int)profile.GetNetworkConnectivityLevel();
            if (profile.IsWlanConnectionProfile)
            {
                data.Ssid = profile.WlanConnectionProfileDetails.GetConnectedSsid();
            }
            var hostNames = NetworkInformation.GetHostNames();
            var ipAddressString = hostNames.FirstOrDefault(h => h.Type == HostNameType.Ipv4)?.DisplayName;
            IPAddress ipAddress = IPAddress.Parse(ipAddressString);
            data.IpAddress = BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0);
            data.Bssid = profile.NetworkAdapter.NetworkAdapterId;
            data.NativeObject = profile;
            data.SignalStrength = profile.GetSignalBars();
            return Task.FromResult(data);
#elif ANDROID
#endif
        }

    }
}
