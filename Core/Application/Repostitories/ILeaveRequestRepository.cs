using Domain.Entities;

namespace Application.Repostitories;

public interface ILeaveRequestRepository
{
    Task<List<LeaveRequest>> GetByEmployeeIdAsync(string id);
    Task<List<LeaveRequest>> GetByManagerIdAsync(string id);    
}