namespace Domain.Entities;

public class Departman  : BaseEntity
{ 
    public string Name { get; set; }
    public List<AppUser> Users { get; set; }    
    public List<PurchaseRequest> PurchaseRequests { get; set; }
}