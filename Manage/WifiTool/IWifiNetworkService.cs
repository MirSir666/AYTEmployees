﻿using AYTEmployees.WifiTool.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AYTEmployees.WifiTool
{
    public interface IWifiNetworkService : IDisposable
    {
        Task<NetworkData> ConnectWifi(string ssid, string password);
        Task<NetworkData> GetNetworkInfo();
        void DisconnectWifi(string ssid);
        Task<bool> OpenWifiSetting();
        Task<List<NetworkData>> ScanWifiNetworks();
    }    
}
