using System.Text.Json.Serialization;

namespace LogicSolution.Model
{
    public class TimeLogs
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public string LogType { get; set; }
        public string LogDate { get; set; }
        public string LogTime { get; set; }
    }
}
