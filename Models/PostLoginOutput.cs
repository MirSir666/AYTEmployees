using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models
{
    public class PostLoginOutput
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
