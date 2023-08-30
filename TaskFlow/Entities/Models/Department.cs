namespace TaskFlow.Entities.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public int topdepartment_id { get; set; }
    }
}
