namespace Application.Features.Results.PurchaseOfferResults;

public class GetPurchaseOfferQueryResult
{
    public string Id { get; set; }
    public string CompanyName { get; set; }           // Firma Adı
    public decimal Amount { get; set; }               // Teklif Tutarı
    public string Description { get; set; }           // Açıklama
    public DateTime CreatedAt { get; set; }
    public bool IsApproved { get; set; }
    
}