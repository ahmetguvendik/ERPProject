namespace Domain.Entities;

public class PurchaseOffer : BaseEntity
{
    public string PurchaseRequestId { get; set; }   
    public PurchaseRequest PurchaseRequest { get; set; }
    public string CompanyName { get; set; }           // Firma Adı
    public decimal Amount { get; set; }               // Teklif Tutarı
    public string Description { get; set; }           // Açıklama
    public DateTime CreatedAt { get; set; } 
}