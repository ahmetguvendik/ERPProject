using Domain.Enums;

namespace Domain.Entities;

public class PurchaseRequest : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public string ManagerId { get; set; } 
    public AppUser Manager { get; set; }    
    public Departman Departman { get; set; }
    public string DepartmanId { get; set; } 
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; }
    public string Statues { get; set; }
    public DateTime CreatedAt { get; set; }
    public UrgencyLevel UrgencyLevel { get; set; }  
}