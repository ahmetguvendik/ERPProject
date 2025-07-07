using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class UpdateSearchingPurchaseCommand : IRequest
{
    public string Id { get; set; }
}