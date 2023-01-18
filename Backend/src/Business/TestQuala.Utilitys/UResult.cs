using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuala.Utilitys
{
#nullable disable

    public class UResult
    {
        public static Result Error(string msg, object? res = null!) { return new Result() { Error = 1, Message = msg, Values = res }; }
        public static Result Ok(string msg, object? res = null!) { return new Result() { Error = 0, Message = msg, Values = res }; }

    }
    public class Result
    {
        public int Error { get; set; }
        public string Message { get; set; } = null!;
        public object Values { get; set; } = null!;
    }
}
