namespace TaskFlow.Entities.Models
{
    public class Responsibility
    {
        public int id { get; set; }
        public int task_id { get; set; }
        public int employee_id { get; set; }
        public string responsibility { get; set; }
    }
}
