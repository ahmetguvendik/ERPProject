using Domain.Enums;
using MediatR;

namespace Application.Features.Commands.RequestCommands;

public class CreateRequestCommand : IRequest
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