using Domain.Enums;

namespace DTO.LeaveRequestDto;

public class GetLeaveRequestByEmployeeIdDto
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