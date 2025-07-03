using Application.Features.Commands.PurchaseCommands;
using FluentValidation;

namespace Application.Validations.PurchaseValidation;

public class CreatePurchaseValidation : AbstractValidator<CreatePurchaseCommand>
{
    public CreatePurchaseValidation()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId boş bırakılamaz.");

        RuleFor(x => x.ManagerId)
            .NotEmpty()
            .WithMessage("ManagerId boş bırakılamaz.");

        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("DepartmentId boş bırakılamaz.");

        RuleFor(x => x.Reason)
            .NotEmpty()
            .WithMessage("Talep nedeni boş bırakılamaz.")
            .MaximumLength(500)
            .WithMessage("Talep nedeni 500 karakterden uzun olamaz.");

        RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("En az bir ürün talebi girilmelidir.");

        RuleForEach(x => x.Items).ChildRules(items =>
        {
            items.RuleFor(i => i.ProductName)
                .NotEmpty()
                .WithMessage("Ürün adı boş bırakılamaz.");

            items.RuleFor(i => i.Quantity)
                .GreaterThan(0)
                .WithMessage("Ürün miktarı 0’dan büyük olmalıdır.");

            items.RuleFor(i => i.Description)
                .MaximumLength(1000)
                .WithMessage("Ürün açıklaması 1000 karakterden uzun olamaz.")
                .When(i => !string.IsNullOrEmpty(i.Description));
        });
    }
}