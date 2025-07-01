using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers;

public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand>
{
    private readonly IRepository<PurchaseRequest>  _repository;

    public CreatePurchaseCommandHandler(IRepository<PurchaseRequest> repository)
    {
         _repository = repository;
    }
    
    public async Task Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = new PurchaseRequest();
        purchase.Id = Guid.NewGuid().ToString();
        purchase.UserId = request.UserId;
        purchase.CreatedAt = DateTime.Now;
        purchase.UrgencyLevel = request.UrgencyLevel;
        purchase.DepartmanId = request.DepartmentId;
        purchase.ProductName = request.ProductName;
        purchase.Reason = request.Reason;
        purchase.Quantity = request.Quantity;
        purchase.Statues = "Talep Alındı";
        await _repository.CreateAsync(purchase);
        await _repository.SaveAsync();
    }
}