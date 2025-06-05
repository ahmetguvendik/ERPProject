using Domain.Enums;

namespace DTO.LeaveRequestDto;

public class GetLeaveRequestByManagerIdDto
{
    public string Id { get; set; }  
    public string EmployeeName { get; set; }
    public string? ManagerId { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestType Type { get; set; } 
    public string Status { get; set; } 
    public string? RejectionReason { get; set; }
    public DateTime CreatedAt { get; set; }    
}