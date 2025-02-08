using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class DictDto
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
    }


    public class DictChildrenDto
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("children")]
        public List<DictChildrenDto> Children { get; set; }
    }
}
