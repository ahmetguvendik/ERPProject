using Application.Features.Commands.PurchaseCommands;
using Domain.Entities;

namespace Application.Features.Results.PurchaseResults;

public class GetPurchaseByIdQueryResult
{
    
    public string Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
}