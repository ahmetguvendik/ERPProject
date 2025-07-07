using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class UpdateApprovedOfferCommand : IRequest
{
    public string Id { get; set; }
    public bool IsApproved { get; set; }
    public DateTime? ApprovedTime { get; set; }  
}