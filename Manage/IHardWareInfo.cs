using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;



#if ANDROID
using static Android.Provider.Settings;
using Android.OS;
using Android.Content;
using Android.Text.Format;
using Android.App;
using Android.Net.Wifi;

#endif

namespace AYTEmployees.Manage
{
    public interface IHardWareInfo
    {
        string GetAppSn();
    }

    public class HardWareInfo : IHardWareInfo
    {
        public string GetBIOS()
        {
            ManagementClass mc = new ManagementClass("Win32_BIOS");
            ManagementObjectCollection moc = mc.GetInstances();
            string strID = null;
            foreach (ManagementObject mo in moc)
            {
                strID = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }
            return strID;
        }

        public string GetBoardID()
        {
            string st = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_BaseBoard");
            foreach (ManagementObject mo in mos.Get())
            {
                st = mo["SerialNumber"].ToString();
            }
            return st;
        }



        public string GetAppSn()
        {
            string appSn = "NONE";

#if ANDROID
            var context = Android.App.Application.Context;
            appSn= "AYT" + Secure.GetString(context.ContentResolver, Secure.AndroidId).Substring(2, 12);
#else
   string baseId = GetBaseBoardInfo();
            string diskId = GetHardDiskID();
            if (string.IsNullOrWhiteSpace(baseId + diskId))
                return appSn;

                appSn="AYT" + MD5Encrypt.Encrypt(baseId + diskId).Substring(8, 12).ToUpper();
#endif



            return appSn;
        }

        /// <summary>
        /// 获取主板信息
        /// </summary>
        /// <returns></returns>
        private string GetBaseBoardInfo()
        {
            string SerialNumber = "";
            try
            {
                ManagementClass mc = new ManagementClass("Win32_BaseBoard");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    SerialNumber = mo.Properties["SerialNumber"].Value.ToString();
                    break;
                }
            }
            catch
            {

            }
            return SerialNumber;
        }

        /// <summary>
        /// 取第一块硬盘编号
        /// </summary>
        /// <returns></returns>
        private string GetHardDiskID()
        {
            string SerialNumber = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PhysicalMedia");
                foreach (ManagementObject mo in searcher.Get())
                {
                    SerialNumber = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return SerialNumber;
            }
            catch
            {

            }
            return SerialNumber;
        }


    }


}
