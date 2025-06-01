using Application.Repostitories;
using Domain.Entities;
using Persistance.Context;

namespace Persistance.Repositories;

public class LeaveQuotaRepository : ILeaveQuotaRepository
{
    private readonly ERPDbContext _context;

    public LeaveQuotaRepository(ERPDbContext context)
    {
         _context = context;
    }
    
    public async Task<LeaveQuota> GetByUserIdAsync(string userId)
    {
        var value =  _context.LeaveQuotas.Where(x=>x.EmployeeId == userId).FirstOrDefault();
        return value;
    }
}