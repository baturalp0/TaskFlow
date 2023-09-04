using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Entities.Models
{
    public class Task
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MinLength(5, ErrorMessage = "Minimum 5 karakter girilmelidir.")]
        [MaxLength (30, ErrorMessage = "Maximum 30 karakter girilmelidir.")]
        public string header { get; set; }
        public DateTime start { get; set; }
        public DateTime deadline { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MinLength(10, ErrorMessage = "Minimum 10 karakter girilmelidir.")]
        [MaxLength(200, ErrorMessage = "Maximum 200 karakter olabilir.")]
        public string description { get; set; }
        public int employeer_id { get; set; }
        public int employees_id { get; set; }
        public int priority_id { get; set; }
        public bool iscompleted { get; set; }
        public DateTime createdate { get; set; }
        public string reports_id { get; set; }
    }
}
