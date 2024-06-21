using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core
{
   public  class Result
    {
        public object Data { get; set; }
        public bool IsValid { get; set; } = true;
        public string Message { get; set; }

        public Result Fail(string message) => new Result() { 
        IsValid = false,
        Message = message,
        Data = null
        };

        public Result Success(object data, string message) => new Result()
        {
            IsValid = true,
            Message = message,
            Data = data
        };
    }
}
