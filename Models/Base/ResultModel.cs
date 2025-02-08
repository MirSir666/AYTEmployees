using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Models.Base
{

    public class ResultModel 
    {

        public bool IsSuccess { get; set; }
        public int Code { get; set; }

        public string Message { get; set; } = "";

        public object Data { get; set; }

        /// <summary>
        /// success
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="errMsg">error message</param>
        /// <returns></returns>
        public static ResultModel Success( string Msg = "成功", object data = default)
        {
           
            return new ResultModel { Message = Msg, IsSuccess = true, Code = 200 };
        }



        /// <summary>
        /// faild
        /// </summary>
        /// <param name="str">error message</param>
        /// <param name="code">status code</param>
        /// <param name="data">data</param>
        /// <returns></returns>
        public static ResultModel Error(string str= "网络错误", int code = 400, object data = default)
        {
            return new ResultModel { Message = str, IsSuccess = false, Code = code };
        }

    }


    public class ResultModel<T>
    {
        /// <summary>
        /// is request success
        /// </summary>
        public bool IsSuccess { get; set; } = true;
        /// <summary>
        /// status code
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///  message
        /// </summary>
        public string Message { get; set; } = "";
        /// <summary>
        /// data
        /// </summary>
        public T Data { get; set; }


        /// <summary>
        /// success
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="errMsg">error message</param>
        /// <returns></returns>
        public static ResultModel<T> Success(T data, string errMsg = "")
        {
            if (data == null)
            {
                return Error("Some errors have occurred");
            }
            return new ResultModel<T> { Data = data, Message = errMsg, IsSuccess = true, Code = 200 };
        }
        /// <summary>
        /// faild
        /// </summary>
        /// <param name="str">error message</param>
        /// <param name="code">status code</param>
        /// <param name="data">data</param>
        /// <returns></returns>
        public static ResultModel<T> Error(string str, int code = 400, T data = default)
        {
            return new ResultModel<T> { Data = data, Message = str, IsSuccess = false, Code = code };
        }
    }
}
