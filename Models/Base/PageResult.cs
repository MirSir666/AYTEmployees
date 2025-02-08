using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models.Base
{
    public class PageResult<T>
    {

        public PageResult()
            : this(Array.Empty<T>(), 0)
        { }

       
        public PageResult(T[] data, int total)
        {
            Data = data;
            Total = total;
        }

       
        public T[] Data { get; set; }

      
        public int Total { get; set; }

      
        public PageData<T> ToPageData()
        {
            return new PageData<T>(Data, Total);
        }

        public PageResult<TResult> ToPageResult<TResult>(Func<T[], TResult[]> func)
        {
            return new PageResult<TResult>(func(Data), Total);
        }
    }
}
