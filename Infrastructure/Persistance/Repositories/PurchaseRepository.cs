using Application.Repostitories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;

public class PurchaseRepository  : IPurchaseRepository
{
    private readonly ERPDbContext  _context;

    public PurchaseRepository(ERPDbContext context)
    {
         _context = context;
    }
    
    public async Task<List<PurchaseRequest>> GetPurchaseRequestsById(string id)
    {
        var values =await _context.PurchaseRequests.Where(x=>x.UserId == id).ToListAsync();
        return values;
    }

    public async Task<List<PurchaseRequest>> GetPurchaseRequestsByManagerId(string id)
    {
        var values =await _context.PurchaseRequests.Include(y=>y.User).Where(x=>x.ManagerId == id).ToListAsync();
        return values;
        
    }
}