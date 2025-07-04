using Domain.Entities;

namespace Application.Repostitories;

public interface IPurchaseOfferRepository
{
    Task<List<PurchaseOffer>> GetPurchaseOfferById(string id);  
}