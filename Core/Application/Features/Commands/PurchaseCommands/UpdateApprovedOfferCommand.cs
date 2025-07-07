using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class UpdateApprovedOfferCommand : IRequest
{
    public string Id { get; set; }
}