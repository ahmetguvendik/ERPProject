namespace Domain.Entities;

public class PurchaseRequestItem : BaseEntity
{
    public string PurchaseRequestId { get; set; }
    public PurchaseRequest PurchaseRequest { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Description { get; set; }
}