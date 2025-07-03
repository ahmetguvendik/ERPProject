namespace Application.Features.Commands.PurchaseCommands;

public class PurchaseRequestItemDto
{
    public string Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
}