using System;

namespace LogicSolution.Model.Dtos
{
    public class TimeLogsDto
    {
        public int UserId { get; set; }
        public string LogType { get; set; }
        public DateTime LogDateTime { get; set; }
    }
}
