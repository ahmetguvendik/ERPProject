using Domain.Enums;

namespace Application.Features.Results.LeaveRequestResults;

public class GetLeaveRequestByManagerIdQueryResult
{
    public string EmployeeName { get; set; }
    public string? ManagerId { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestType Type { get; set; } 
    public string Status { get; set; } 
    public string? RejectionReason { get; set; }
    public DateTime CreatedAt { get; set; }     
}