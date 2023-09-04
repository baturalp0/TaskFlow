using System.ComponentModel.DataAnnotations;


namespace TaskFlow.Entities.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MinLength(5, ErrorMessage = "Minimum 5 karakter girilmelidir.")]
        [MaxLength(30, ErrorMessage = "Maximum 30 karakter girilmelidir.")]
        public string code { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [MinLength(8, ErrorMessage = "Şifre minimum 8 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Şifre maximum 30 karakter olmalıdır.")]
        public string password { get; set; }
    }
}
