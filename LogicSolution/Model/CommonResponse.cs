using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicSolution.Model
{
    public class CommonResponse
    {
        public bool IsError { get; set; }
        public object Data { get; set; }
        public string UserMessage { get; set; } = "Success";
    }
}
