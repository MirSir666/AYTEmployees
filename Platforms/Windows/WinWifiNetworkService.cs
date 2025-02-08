using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.WiFi;
using Windows.Networking.Connectivity;
using Windows.Networking;
using Windows.Security.Credentials;
using AYTEmployees.WifiTool;
using AYTEmployees.WifiTool.Abstractions;
using Windows.Devices.Enumeration;
using Windows.Networking.NetworkOperators;
using System.Net.NetworkInformation;

namespace AYTEmployees.Platforms.Windows
{
    public partial class WinWifiNetworkService : IWifiNetworkService
    {
        public WinWifiNetworkService()
        {
        }

        /// <summary>
        /// Connect Wi-Fi
        /// </summary>
        public async Task<NetworkData> ConnectWifi(string ssid, string password)
        {
            NetworkData networkData = new NetworkData();
            var credential = new PasswordCredential();
            credential.Password = password;
            WiFiAdapter adapter;
            var access = await WiFiAdapter.RequestAccessAsync();
            if (access != WiFiAccessStatus.Allowed)
            {
                Console.WriteLine("No Wi-Fi Access Status");
            }
            else
            {
                var result = await DeviceInformation.FindAllAsync(WiFiAdapter.GetDeviceSelector());
                if (result.Count >= 1)
                {
                    adapter = await WiFiAdapter.FromIdAsync(result[0].Id);
                    if (adapter != null)
                    {
                        await adapter.ScanAsync();
                        WiFiAvailableNetwork wiFiAvailableNetwork = null;
                        foreach (var network in adapter.NetworkReport.AvailableNetworks)
                        {
                            if (network.Ssid == ssid)
                            {
                                wiFiAvailableNetwork = network;
                                break;
                            }
                        }
                        if (wiFiAvailableNetwork != null)
                        {
                            var status = await adapter.ConnectAsync(wiFiAvailableNetwork, WiFiReconnectionKind.Automatic, credential);
                            if (status.ConnectionStatus == WiFiConnectionStatus.Success)
                            {
                                var InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                                var hostname = NetworkInformation.GetHostNames().FirstOrDefault(hn => hn.IPInformation?.NetworkAdapter != null && hn.IPInformation.NetworkAdapter.NetworkAdapterId == InternetConnectionProfile?.NetworkAdapter.NetworkAdapterId);
                                networkData.Ssid = hostname.ToString();
                                Console.WriteLine("OK");
                            }
                            else if (status.ConnectionStatus == WiFiConnectionStatus.InvalidCredential)
                            {
                                Console.WriteLine("Invalid Credential");
                            }
                            else if (status.ConnectionStatus == WiFiConnectionStatus.Timeout)
                            {
                                Console.WriteLine("Timeout");
                            }
                        }
                    }
                }
            }
            return networkData;
        }

        /// <summary>
        /// Disconnect Wi-Fi
        /// </summary>
        public async void DisconnectWifi(string ssid)
        {
            WiFiAdapter adapter;
            var result = await DeviceInformation.FindAllAsync(WiFiAdapter.GetDeviceSelector());
            if (result.Count >= 1)
            {
                adapter = await WiFiAdapter.FromIdAsync(result[0].Id);
                adapter.Disconnect();
            }
        }

        /// <summary>
        /// Get Network Info
        /// </summary>
        public async Task<NetworkData> GetNetworkInfo()
        {
            NetworkData data = new NetworkData();
     
            var profile = NetworkInformation.GetInternetConnectionProfile();
            data.StausId = (int)profile.GetNetworkConnectivityLevel();
            if (profile.IsWlanConnectionProfile)
            {
                data.Ssid = profile.WlanConnectionProfileDetails.GetConnectedSsid();
                data.Bssid = await GetBssid(data.Ssid);
               // data.MacAddress = GetMacAddress();


            }
            var hostNames = NetworkInformation.GetHostNames();
            var ipAddressString = hostNames.FirstOrDefault(h => h.Type == HostNameType.Ipv4)?.DisplayName;
            IPAddress ipAddress = IPAddress.Parse(ipAddressString);
            data.IpAddress = BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0);
            //data.Bssid = profile.NetworkAdapter.NetworkAdapterId;
            data.NativeObject = profile;
            data.SignalStrength = profile.GetSignalBars();
            return data;
        }

        public  async Task<String> GetBssid(String ssid)
        {
            foreach (var adapter in await WiFiAdapter.FindAllAdaptersAsync())
            {
                foreach (var network in adapter.NetworkReport.AvailableNetworks)
                {
                    if (network.Ssid == ssid)
                    {
                        return network.Bssid;
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// Open Wi-Fi Setting
        /// </summary>
        public async Task<bool> OpenWifiSetting()
        {
            return await Launcher.CanOpenAsync(new Uri("ms-settings:network-wifi"));
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Scan Wi-Fi Networks
        /// </summary>
        public async Task<List<NetworkData>> ScanWifiNetworks()
        {
            List<NetworkData> wifiNetworks = new List<NetworkData>();

            var accessStatus = await WiFiAdapter.RequestAccessAsync();
            if (accessStatus == WiFiAccessStatus.Allowed)
            {
                var result = await WiFiAdapter.FindAllAdaptersAsync();
                if (result.Count > 0)
                {
                    var wifiAdapter = result[0];
                    var availableNetworks = wifiAdapter.NetworkReport.AvailableNetworks;
                    foreach (var network in availableNetworks)
                    {
                        wifiNetworks.Add(new NetworkData
                        {
                            Ssid = network.Ssid,
                            Bssid = network.Bssid,
                            SignalStrength = network.SignalBars,
                            SecurityType = network.PhyKind
                        });
                    }
                }
            }
            return wifiNetworks;
        }
    }
}
