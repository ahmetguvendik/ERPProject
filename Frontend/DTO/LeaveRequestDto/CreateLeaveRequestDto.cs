using Domain.Enums;

namespace DTO.LeaveRequestDto;

public class CreateLeaveRequestDto
{
    public string EmployeeId { get; set; }
    public string ManagerId { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestType RequestType { get; set; } 
    public string Status { get; set; } 
    public string? RejectionReason { get; set; }
    public DateTime CreatedAt { get; set; }     
}