using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class UpdateRejectPurchaseCommand : IRequest
{ 
    public string Id { get; set; }
    public string Statues { get; set; }
    public string? RejectionReason { get; set; }
}