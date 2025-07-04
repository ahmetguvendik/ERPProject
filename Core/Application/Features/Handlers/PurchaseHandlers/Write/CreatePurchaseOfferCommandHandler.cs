using Application.Features.Commands.RequestCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Write;

public class CreatePurchaseOfferCommandHandler : IRequestHandler<CreatePurchaseOfferCommand>
{
    private readonly IRepository<PurchaseOffer> _repository;

    public CreatePurchaseOfferCommandHandler(IRepository<PurchaseOffer> repository)
    {
         _repository = repository;
    }
    
    public async Task Handle(CreatePurchaseOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = new PurchaseOffer();
        offer.Id =  Guid.NewGuid().ToString();
        offer.PurchaseRequestId = request.PurchaseRequestId;
        offer.CompanyName = request.CompanyName;
        offer.Description = request.Description;
        offer.CreatedAt = DateTime.Now;
        offer.Amount = request.Amount;
        await _repository.CreateAsync(offer);
        await _repository.SaveAsync();
    }
}