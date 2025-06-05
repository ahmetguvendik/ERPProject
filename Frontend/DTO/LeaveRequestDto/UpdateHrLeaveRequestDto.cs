namespace DTO.LeaveRequestDto;

public class UpdateHrLeaveRequestDto
{
    public string Id { get; set; }
    public string Status { get; set; } 
    public string? RejectionReason { get; set; }
}