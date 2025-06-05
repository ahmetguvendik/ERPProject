namespace DTO.LeaveRequestDto;

public class UpdateHrRejectLeaveRequestDto
{
    public string Id { get; set; }
    public string Status { get; set; } 
    public string? RejectionReason { get; set; }
}