using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class UpdateBackToManagerPuchaseCommand : IRequest
{
    public string Id { get; set; }
}