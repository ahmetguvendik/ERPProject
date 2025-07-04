using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Results.PurchaseResults;

public class GetPurchaseByManagerIdQueryResult
{
 
    public string Id { get; set; }
    public List<PurchaseRequestItem> Items { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public UrgencyLevel UrgencyLevel { get; set; }
    public string Username { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public string? RejectionReason { get; set; }
}