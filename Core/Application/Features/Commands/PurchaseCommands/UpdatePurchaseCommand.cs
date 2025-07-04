using Domain.Enums;
using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class UpdatePurchaseCommand : IRequest
{
    public string Id { get; set; }
    public List<PurchaseRequestItemDto> Items { get; set; }   
}