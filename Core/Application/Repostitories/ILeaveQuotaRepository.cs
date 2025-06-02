using Domain.Entities;

namespace Application.Repostitories;

public interface ILeaveQuotaRepository
{
    Task<List<LeaveQuota>> GetByUserIdAsync(string userId);
    Task UpdateAsync(LeaveQuota entity);
    
}