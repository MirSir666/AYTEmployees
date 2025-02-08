using AYTEmployees.Manage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees
{
    public static class ARPTool
    {
        public static IEnumerable<string> GetAllIPv4s()
        {
            var ip = Utility.GetLocalIPAddress();
            var list = new List<string>();
            var ips = ip.Split('.');
            var ip1 = ips[0];
            var ip2 = ips[1];
            if (int.TryParse(ip1, out int ipint1) && int.TryParse(ip2, out int ipint2))
            {
                for (int i = 0; i < 255; i++)
                {
                    list.Add($"{ip1}.{ip2}.{ips[2]}.{i}");
                }
            }
            return list;
        }
        public static IEnumerable<string> GetIPv4s()
        {

            Process p = null;
            string output = string.Empty;
            //var ips = new List<IPAddress>();
            try
            {

                p = Process.Start(new ProcessStartInfo("arp", "-a")
                {
                    CreateNoWindow = true, //显示窗口
                    UseShellExecute = false, //关闭Shell的使用
                    RedirectStandardOutput = true, //重定向标准输出                   
                });
                output = p.StandardOutput.ReadToEnd();
                var arpIps = output.Split('\n').Skip(3).ToList().Where(o => o.Contains("动态") || o.Contains("dynamic"));

                return arpIps.Select(o => o.Split(' ')[2]).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("IPInfo: Error Retrieving 'arp -a' Results", ex);
            }


        }
    }
}
