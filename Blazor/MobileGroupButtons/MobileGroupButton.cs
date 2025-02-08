using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Blazor.MobileGroupButtons
{
    public class MobileGroupButton<T>
    {
        public MobileGroupButtonsItem<T> Item { get; set; }

        public string ClassName { get; set; }

        public int Index { get; set; }
    }
}
