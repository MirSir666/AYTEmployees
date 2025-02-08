
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees
{
    public class NetScannerTool
    {

        public static async Task<IEnumerable<string>> CheckConnect(int port, params string[] ips)
        {

            var tasks = new List<Task<(bool bit, string ip)>>();
            foreach (string ip in ips)
            {
                tasks.Add(CheckEnabled(ip, port));
            }
            await Task.WhenAll(tasks.ToArray());
            return tasks.Select(o => o.Result).Where(o => o.bit).Select(o => o.ip).ToArray(); ;
        }


        public static async Task<(bool bit, string ip)> CheckEnabled(string ip, int port)
        {

            using (TcpClient client = new TcpClient())
            {
                var task = client.ConnectAsync(ip, port);
                var tdelay = Task.Delay(100);
                var rettask = await Task.WhenAny(task, tdelay);

                if (rettask == task)
                    return (true, ip);
                return (false, ip);
            };

        }

        public static async Task<IEnumerable<string>> CheckCurrentServies(params string[] ips)
        {
            var tasks = new List<Task<(bool bit, string ip)>>();
            foreach (string ip in ips)
                tasks.Add(CheckIpStatus(ip));

            await Task.WhenAll(tasks.ToArray());
            return tasks.Select(o => o.Result).Where(o => o.bit).Select(o => o.ip).ToArray();

        }




        public static async Task<(bool bit, string ip)> CheckIpStatus(string ip,int port=800)
        {
            var url = "自定义";
            try
            {

                var handler = new HttpClientHandler();
                handler.UseCookies = false;
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                var httpCli = new HttpClient(handler);
                httpCli.Timeout = TimeSpan.FromSeconds(5);

                // HttpClient client = new HttpClient();
                var str = await httpCli.GetAsync(url);
            
                    var s =await str.Content.ReadAsStringAsync();
                return (true, ip);
            }
            catch (Exception ex)
            {
                return (false, ip);
            }
        }



    }

}
