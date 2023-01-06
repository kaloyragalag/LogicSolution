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

    public class StripComments
    {
        public string Text { get; set; }
        public string[] CommentSymbols { get; set; }
    }
}
