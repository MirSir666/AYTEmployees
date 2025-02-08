using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models.Base
{
    public class PageData<T>
    {

        public PageData()
            : this(new List<T>(), 0)
        { }

        public PageData(IEnumerable<T> rows, int total)
        {
            Rows = rows;
            Total = total;
        }


        public IEnumerable<T> Rows { get; set; }


        public int Total { get; set; }
    }
}
