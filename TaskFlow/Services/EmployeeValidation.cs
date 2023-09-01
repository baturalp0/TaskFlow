using TaskFlow.Entities.Models;
using FluentValidation;

namespace TaskFlow.Services
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation() 
        {

            this.RuleFor(x => x.code).NotEmpty().WithMessage("Bu alan boş olamaz")
                    .MinimumLength(6).WithMessage("Personel kodu 6 karakterden az olamaz")
                    .MaximumLength(30).WithMessage("Personel kodu 30 karakterden fazla olamaz.");

            RuleFor(x => x.password).NotEmpty().WithMessage("Bu alan boş olamaz")
                .MaximumLength(16).WithMessage("Şifre 16 karakterden uzun olamaz.")
                .MinimumLength(6).WithMessage("Şifre 6 karakterden az olamaz");

        }

    }
}
