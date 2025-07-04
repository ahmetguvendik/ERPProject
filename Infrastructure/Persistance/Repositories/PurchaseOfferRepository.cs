using Application.Repostitories;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories;

public class PurchaseOfferRepository : IPurchaseOfferRepository
{
    private readonly ERPDbContext  _context;

    public PurchaseOfferRepository(ERPDbContext context)
    {
         _context = context;
    }
    


    public async Task<List<PurchaseOffer>> GetPurchaseOfferById(string id)
    {
        var values =  _context.PurchaseOffers.Where(x => x.PurchaseRequestId == id).ToList();
        return values;
        
    }
}