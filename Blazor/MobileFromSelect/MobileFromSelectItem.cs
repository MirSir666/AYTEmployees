using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Blazor.MobileFromSelect
{
    public class MobileFromSelectItem<T>
    {
        public string Text { get; set; }

        public T Value { get; set; }
    }
}
