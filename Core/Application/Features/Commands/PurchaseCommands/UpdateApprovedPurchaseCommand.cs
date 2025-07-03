using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class UpdateApprovedPurchaseCommand : IRequest
{
    public string Id { get; set; }
    public string Statues { get; set; }
}