using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Helper
{
    public class Result<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Result(int Code, string Message, T Data)
        {
            this.Code = Code;
            this.Message=Message;
            this.Data = Data;
        }

   
    }
}
