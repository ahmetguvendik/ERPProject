using MediatR;

namespace Application.Features.Commands.RequestCommands;

public class UpdateHrRejectLeaveRequestCommand : IRequest
{
    public string Id { get; set; }
    public string Status { get; set; } 
    public string? RejectionReason { get; set; }
}