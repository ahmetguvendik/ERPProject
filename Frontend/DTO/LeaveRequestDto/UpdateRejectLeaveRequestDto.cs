namespace DTO.LeaveRequestDto;

public class UpdateRejectLeaveRequestDto
{
    
    public string Id { get; set; }
    public string Status { get; set; } 
    public string? RejectionReason { get; set; }
}