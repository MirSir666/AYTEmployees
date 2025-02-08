using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AYTEmployees
{
    internal class Verify
    {
        ///<summary>        
        /// 判断是否是Ip地址        
        /// </summary>        
        /// <param name="str1"></param>        
        /// <returns></returns>

        public static bool IsIPAddress(string ip)
        {

            if (string.IsNullOrEmpty(ip) || ip.Length < 7 || ip.Length > 15) return false;

            string regformat = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);

            return regex.IsMatch(ip);

        }
        public static bool IsIPPort(string port)

        {

            bool isPort = false;

            int portNum;

            isPort = Int32.TryParse(port, out portNum);


            return isPort && portNum >= 0 && portNum <= 65535;
        }
    }
}
