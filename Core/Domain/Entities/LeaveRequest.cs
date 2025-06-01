using Domain.Enums;

namespace Domain.Entities;

public class LeaveRequest : BaseEntity
{
    public string EmployeeId { get; set; }
    public string ManagerId { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RequestType Type { get; set; } 
    public string Status { get; set; } = "Beklemede"; // "Beklemede", "Onaylandı", "Reddedildi"
    public string? RejectionReason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    public AppUser User { get; set; }   
}