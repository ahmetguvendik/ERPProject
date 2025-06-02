using Domain.Enums;

namespace Application.Features.Results.LeaveRequestResults;

public class GetLeaveRequestByEmployeeIdQueryResult
{
    public string EmployeeId { get; set; }
    public string? ManagerName { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestType Type { get; set; } 
    public string Status { get; set; } 
    public string? RejectionReason { get; set; }
    public DateTime CreatedAt { get; set; }
}