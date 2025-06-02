using Application.Features.Commands.RequestCommands;
using FluentValidation;

namespace Application.Validations.LeaveRequestValidation;

public class CreateLeaveRequestValidation : AbstractValidator<CreateRequestCommand>
{
    public CreateLeaveRequestValidation()
    {
        RuleFor(x=>x.StartDate).NotEmpty().WithMessage("Start date is required");
        RuleFor(x=>x.EndDate).NotEmpty().WithMessage("End date is required");
        RuleFor(x=>x.RequestType).NotEmpty().WithMessage("Request type is required");
    }
}