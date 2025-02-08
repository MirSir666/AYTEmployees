using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AYTEmployees.Manage
{
    public static class HttpClientExtensions
    {
        public static  async Task<T> ReadContentAsAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString =await  response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(dataAsString);
        }


        public static async Task<T> Post<T, Content>(this HttpClient http, string url, Content content)
        {
            var stringcontent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var response = await http.PostAsync(http.BaseAddress + url, stringcontent);
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("接口错误:" + url + response.ReasonPhrase);
            
            
            var retval = await response.ReadContentAsAsync<T>();
            return retval;

        }

        public static async Task<T> Post<T>(this HttpClient http,string url,string content="")
        {
            var stringcontent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await http.PostAsync(http.BaseAddress + url, stringcontent);
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("接口错误:" + url + response.ReasonPhrase);
            

            var retval = await response.ReadContentAsAsync<T>();
            return retval;
        }
    }
}
