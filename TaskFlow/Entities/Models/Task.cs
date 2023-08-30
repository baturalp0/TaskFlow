namespace TaskFlow.Entities.Models
{
    public class Task
    {
        public int id { get; set; }
        public string header { get; set; }
        public DateTime start { get; set; }
        public DateTime deadline { get; set; }
        public string description { get; set; }
        public int employeer_id { get; set; }
        public int employees_id { get; set; }
        public int priority_id { get; set; }
        public bool iscompleted { get; set; }
        public DateTime createdate { get; set; }
        public string reports_id { get; set; }
    }
}
