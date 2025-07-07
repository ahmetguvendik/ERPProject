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
        var values =await _context.PurchaseRequests.Include(x=>x.Items).Where(x=>x.UserId == id).ToListAsync();
        return values;
    }

    public async Task<List<PurchaseRequest>> GetPurchaseRequestsByManagerId(string id)
    {
        var values =await _context.PurchaseRequests.Include(y=>y.User).Include(y=>y.Items).Where(x=>x.ManagerId == id).ToListAsync();
        return values;
        
    }

    public async Task<List<PurchaseRequest>> GetPurchaseRequestsByApprovedManager()
    {
        var values =await _context.PurchaseRequests.Include(y=>y.User).Include(z=>z.Manager).Include(y=>y.Items).Where(x=>x.Status == "Müdür Onayladı").ToListAsync();
        return values;
    }
    
        public async Task<PurchaseRequest?> GetByIdWithItemsAsync(string id)
        {
            return await _context.PurchaseRequests
                .Include(pr => pr.Items)
                .FirstOrDefaultAsync(pr => pr.Id == id);
        }

        public async Task<List<PurchaseRequest?>> GetSearchingPurchase()
        {
            var values =await _context.PurchaseRequests.Include(y=>y.User).Include(z=>z.Manager).Include(y=>y.Items).Where(x=>x.Status == "SatınAlma Araştırıyor").ToListAsync();
            return values;
        }
}