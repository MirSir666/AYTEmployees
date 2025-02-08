using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Blazor.MobileFromSelect
{
    public class MobileFromSelectButton<T>
    {
        public MobileFromSelectItem<T> Item { get; set; }

        public string ClassName { get; set; }

        public int Index { get; set; }
    }
}
