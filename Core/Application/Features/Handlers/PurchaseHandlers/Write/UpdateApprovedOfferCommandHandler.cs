using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

public class UpdateApprovedOfferCommandHandler : IRequestHandler<UpdateApprovedOfferCommand>
{
    private readonly IRepository<PurchaseOffer> _repository;

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
        bool isAlreadyApproved = allOffers.Any(x =>
            x.PurchaseRequestId == approvedOffer.PurchaseRequestId &&
            x.IsApproved &&
            x.Id != approvedOffer.Id);

        if (isAlreadyApproved)
            throw new Exception("Bu satın alma talebi için zaten onaylanmış bir teklif var.");

        // Diğer teklifleri kontrol et ve güncelle
        var relatedOffers = allOffers
            .Where(x => x.PurchaseRequestId == approvedOffer.PurchaseRequestId)
            .ToList();

        foreach (var offer in relatedOffers)
        {
            if (offer.Id == request.Id)
            {
                offer.IsApproved = true;
                offer.ApprovedTime = DateTime.Now;
            }
            else
            {
                offer.IsApproved = false;
                offer.ApprovedTime = null;
            }

            // Güncelleme işlemi
            await _repository.UpdateAsync(offer);
            await _repository.SaveAsync();
        }
    }
}