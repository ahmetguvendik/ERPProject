using Domain.Enums;

namespace Application.Features.Results.PurchaseResults;

public class GetPurchaseByManagerIdQueryResult
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; }
    public string Statues { get; set; }
    public DateTime CreatedAt { get; set; }
    public UrgencyLevel UrgencyLevel { get; set; }
    public string Username { get; set; }
}