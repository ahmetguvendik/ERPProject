using Domain.Enums;

namespace DTO.PurchaseRequestDto;

public class GetPurchaseByUserIdDto
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; }
    public string Statues { get; set; }
    public DateTime CreatedAt { get; set; }
    public UrgencyLevel UrgencyLevel { get; set; }  
}