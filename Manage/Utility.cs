using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;




#if ANDROID
using Android.OS;
using Android.Content;
using Android.Text.Format;
using Android.App;
using Android.Net.Wifi;
#endif

namespace AYTEmployees.Manage
{
    public static class Utility
    {

      

        public static async Task<Location> GetLocation()
        {
            try
            {
                PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status == PermissionStatus.Denied) {
                    return null;
                }

                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location != null)
                    return location;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;

            //GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            //TaskCompletionSource<Location> locationTaskCompletionSource = new TaskCompletionSource<Location>();

            //MainThread.BeginInvokeOnMainThread(async () =>
            //{
            //    try
            //    {
            //        locationTaskCompletionSource.SetResult(await Geolocation.GetLocationAsync(request));
            //    }
            //    catch (Exception exception)
            //    {
            //        locationTaskCompletionSource.SetException(exception);
            //        locationTaskCompletionSource.SetResult(null);
            //    }
            //});

            //return locationTaskCompletionSource.Task;
        }

        /// <summary>
        /// Guid转Long
        /// </summary>
        /// <param name="strGuid"></param>
        /// <returns></returns>
        public static long GuidToLong()
        {
            var buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }


        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            //return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            DateTime startUtc = new DateTime(1970, 1, 1);
            DateTime nowUtc = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Utc);
            return (long)(nowUtc - startUtc).TotalSeconds;
        }

        /// <summary>
        /// GUID转短（16位）字符串
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string Guid2ShortString()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        public static string GetLocalIPAddress()
        {

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return string.Empty;

            var result = "";
#if ANDROID
            //WifiNetworkSpecifier
            //var tt = OperatingSystem.Version;
            //if (OperatingSystem.IsAndroidVersionAtLeast(30))
            //{ 
            //}

            //if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            //{ 
            //}

            WifiManager wifiMgr = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
            WifiInfo wifiInfo = wifiMgr.ConnectionInfo;
            int ip = wifiInfo.IpAddress;
           var ipAddress = Formatter.FormatIpAddress(ip);
            result = ipAddress;

#else
  result = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork).ToString();
#endif

            return result;
            //IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            //var ippaddress = host
            //    .AddressList
            //    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            //return ippaddress.ToString();
        }
    }
}
