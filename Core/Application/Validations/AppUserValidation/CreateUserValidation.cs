using Application.Features.Commands;
using FluentValidation;

namespace Application.Validations.AppUserValidation;

public class CreateUserValidation: AbstractValidator<CreateUserCommand>
{
    public CreateUserValidation()
    {
        RuleFor(x=>x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x=>x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x=>x.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(x=>x.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(x=>x.Password).NotEmpty().WithMessage("Password is required.");
        RuleFor(x=>x.TCNo).NotEmpty().WithMessage("TC is required.");
        RuleFor(x=>x.Gender).NotEmpty().WithMessage("Gender is required.");
        RuleFor(x=>x.JobTitle).NotEmpty().WithMessage("JobTitle is required.");
        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("BirthDate is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("BirthDate cannot be in the future.");
        RuleFor(x=>x.StartingJob).NotEmpty().WithMessage("Starting job is required.");
        RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Phone Number is required.");
        RuleFor(x=>x.SicilNo).NotEmpty().WithMessage("Sicil No is required.");
        RuleFor(x=>x.Disruptions).NotEmpty().WithMessage("Disruptions is required.");
        RuleFor(x=>x.Prim).NotEmpty().WithMessage("Prim is required.");
        RuleFor(x=>x.DepartmanId).NotEmpty().WithMessage("Departman is required.");
        RuleFor(x=>x.ManagerId).NotEmpty().WithMessage("Manager is required.");
        RuleFor(x=>x.NetSalary).NotEmpty().WithMessage("Net Salary is required.");
        RuleFor(x=>x.BrutSalary).NotEmpty().WithMessage("Brut Salary is required.");
        
    }
}