using Application.Repostitories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;

public class LeaveRequestRepository  : ILeaveRequestRepository
{
    private readonly ERPDbContext _context;

    public LeaveRequestRepository(ERPDbContext context)
    {
         _context = context;
    }
    
    public async Task<List<LeaveRequest>> GetByEmployeeIdAsync(string id)
    {
        var values = _context.LeaveRequests.Include(y=>y.Manager).Where(l => l.EmployeeId == id).ToList();
        return values;
    }

    public async Task<List<LeaveRequest>> GetByManagerIdAsync(string id)
    {
        var values = _context.LeaveRequests.Include(y=>y.Employee).Where(l => l.ManagerId == id).ToList();  
        return values;
    }

    public async Task<List<LeaveRequest>> GetByApprovedAsync()
    {
        var values = _context.LeaveRequests.Include(y=>y.Employee).Include(y=>y.Manager).Where(l => l.Status == "Müdür Onayladı").ToList();  
        return values;
    }
}