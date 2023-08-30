namespace TaskFlow.Entities.Models
{
    public class Report
    {
        public int id { get; set; }
        public int task_id { get; set; }
        public string content { get; set; }
        public int employee_id { get; set; }
    }
}
