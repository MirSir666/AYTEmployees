using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees
{
    public class Settings
    {
        public static void Init() {
         
            Preferences.Set(UserConst.ServiceUrl, "http://");
        }

        public static T GetObj<T>(string key)
        {
            var val = Preferences.Get(key,default(string));
            if (val == null)
                return default(T);


            return JsonConvert.DeserializeObject<T>(val);
        }


        public static void SetObj<T>(string key,T val)
        {
            Preferences.Set(key, JsonConvert.SerializeObject(val));
        }

       


    }
}
