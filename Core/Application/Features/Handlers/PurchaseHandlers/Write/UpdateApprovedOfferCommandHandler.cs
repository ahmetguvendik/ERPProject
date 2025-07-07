using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Write;

public class UpdateApprovedOfferCommandHandler : IRequestHandler<UpdateApprovedOfferCommand>
{
    private readonly IRepository<PurchaseOffer>  _repository;

    public UpdateApprovedOfferCommandHandler(IRepository<PurchaseOffer> repository)
    {
         _repository = repository;
    }
    
    public async Task Handle(UpdateApprovedOfferCommand request, CancellationToken cancellationToken)
    {
        var approvedOffer = await _repository.GetByIdAsync(request.Id);
        if (approvedOffer == null)
            throw new Exception("Teklif bulunamadı.");

        // Daha önce onaylanmış başka bir teklif var mı?
        var allOffers = await _repository.GetAllAsync();
        var alreadyApproved = allOffers.FirstOrDefault(x => 
            x.PurchaseRequestId == approvedOffer.PurchaseRequestId &&
            x.IsApproved && x.Id != approvedOffer.Id);

        if (alreadyApproved != null)
            throw new Exception("Bu satın alma talebi için zaten onaylanmış bir teklif var.");

        // Diğer teklifleri reddet
        var relatedOffers = allOffers
            .Where(x => x.PurchaseRequestId == approvedOffer.PurchaseRequestId)
            .ToList();

        foreach (var offer in relatedOffers)
        {
            offer.IsApproved = offer.Id == request.Id;
            offer.ApprovedTime = offer.IsApproved ? DateTime.Now : null;
            await _repository.UpdateAsync(offer);
        }
    }
}