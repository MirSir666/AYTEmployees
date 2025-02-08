using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Blazor
{
    public class HtmlWrapper<T>
    {
        public T Item { get; set; }
        public string Class { get; set; }
        public HtmlWrapper(T item, string initialClass)
        {
            Item = item;
            Class = initialClass;
        }

        public HtmlWrapper(T item, Func< T, string> func)
        {
            Item = item;
            Class = func.Invoke(item);
        }
    }
}
