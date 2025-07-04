using Domain.Enums;

namespace Domain.Entities;

public class PurchaseRequest : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public string ManagerId { get; set; }
    public AppUser Manager { get; set; }
    public string DepartmanId { get; set; }
    public Departman Departman { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public string Reason { get; set; }
    public string? RejectionReason { get; set; }
    public UrgencyLevel UrgencyLevel { get; set; }
    public ICollection<PurchaseRequestItem> Items { get; set; }  
}