using MediatR;

namespace Application.Features.Commands.RequestCommands;

public class CreatePurchaseOfferCommand : IRequest
{
    public string PurchaseRequestId { get; set; }   
    public string CompanyName { get; set; }           // Firma Adı
    public decimal Amount { get; set; }               // Teklif Tutarı
    public string Description { get; set; }           // Açıklama
}