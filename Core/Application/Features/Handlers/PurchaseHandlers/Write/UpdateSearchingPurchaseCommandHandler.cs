using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Write;

public class UpdateSearchingPurchaseCommandHandler : IRequestHandler<UpdateSearchingPurchaseCommand>
{
    private readonly IRepository<PurchaseRequest> _purchaseRepository;

    public UpdateSearchingPurchaseCommandHandler(IRepository<PurchaseRequest> purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }
    
    public async Task Handle(UpdateSearchingPurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(request.Id);
        purchase.Status = "SatınAlma Araştırıyor";
        purchase.SearchingAt = DateTime.Now;    
        await _purchaseRepository.UpdateAsync(purchase);
        await _purchaseRepository.SaveAsync();  
    }
}