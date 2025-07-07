using Application.Repostitories;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories;

public class PurchaseRequestItemRepository : IPurchaseRequestItemRepository
{
    private readonly ERPDbContext  _context;

    public PurchaseRequestItemRepository(ERPDbContext context)
    {
         _context = context;
    }
    
    public async Task<List<PurchaseRequestItem>> GetById(string id)
    {
        var items =  _context.PurchaseRequestItems
            .Where(i => i.PurchaseRequestId == id)
            .ToList();
        return items;

    }
}