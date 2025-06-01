using Domain.Entities;

namespace Application.Repostitories;

public interface ILeaveQuotaRepository
{
    Task<LeaveQuota> GetByUserIdAsync(string userId);
    
}