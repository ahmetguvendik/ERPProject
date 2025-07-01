using Application.Features.Commands.PurchaseCommands;
using Application.Features.Commands.RequestCommands;
using FluentValidation;

namespace Application.Validations.PurchaseValidation;

public class CreatePurchaseValidation : AbstractValidator<CreatePurchaseCommand>
{
    public CreatePurchaseValidation()
    {
        RuleFor(x=>x.UserId).NotEmpty().WithMessage("Boş Bırakılamaz");
        RuleFor(x=>x.DepartmentId).NotEmpty().WithMessage("Boş Bırakılamaz");
        RuleFor(x=>x.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Bırakılamaz");
        RuleFor(x => x.Quantity).NotEmpty().WithMessage("Adet Boş Bırakılamaz");
        RuleFor(x => x.Reason).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz");
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Miktar sıfırdan büyük olmalı");
    }
}