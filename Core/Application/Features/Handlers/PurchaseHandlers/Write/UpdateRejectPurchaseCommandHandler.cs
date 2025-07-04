using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Write;

public class UpdateRejectPurchaseCommandHandler : IRequestHandler<UpdateRejectPurchaseCommand>
{
    private readonly IRepository<PurchaseRequest> _purchaseRepository;

    public UpdateRejectPurchaseCommandHandler(IRepository<PurchaseRequest> purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }
    
    public async Task Handle(UpdateRejectPurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(request.Id);
        purchase.Status = "Müdür Reddetti";
        purchase.ApprovedAt = DateTime.Now;
        purchase.RejectionReason = request.RejectionReason;
        await _purchaseRepository.UpdateAsync(purchase);
        await _purchaseRepository.SaveAsync();
    }
}