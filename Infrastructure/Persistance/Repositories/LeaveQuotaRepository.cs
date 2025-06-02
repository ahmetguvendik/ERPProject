using Application.Repostitories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;

public class LeaveQuotaRepository : ILeaveQuotaRepository
{
    private readonly ERPDbContext _context;

    public LeaveQuotaRepository(ERPDbContext context)
    {
         _context = context;
    }
    
    public async Task<List<LeaveQuota>> GetByUserIdAsync(string userId)
    {
        var value =  await _context.LeaveQuotas.Where(x=>x.EmployeeId == userId).ToListAsync();
        return  value;
    }

    public async Task UpdateAsync(LeaveQuota entity)
    {
         _context.Set<LeaveQuota>().Update(entity);
    }
}