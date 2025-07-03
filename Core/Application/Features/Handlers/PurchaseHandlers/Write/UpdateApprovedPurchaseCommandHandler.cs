using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Write;

public class UpdateApprovedPurchaseCommandHandler : IRequestHandler<UpdateApprovedPurchaseCommand>
{
    private readonly IRepository<PurchaseRequest> _purchaseRepository;

    public UpdateApprovedPurchaseCommandHandler(IRepository<PurchaseRequest> purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }
    
    public async Task Handle(UpdateApprovedPurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(request.Id);
        purchase.Status = "Müdür Onayladı";
        await _purchaseRepository.UpdateAsync(purchase);
        await _purchaseRepository.SaveAsync();
    }
}