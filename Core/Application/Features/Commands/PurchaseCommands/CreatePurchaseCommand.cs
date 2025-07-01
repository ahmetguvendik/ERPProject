using Domain.Enums;
using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class CreatePurchaseCommand : IRequest
{
    public string UserId { get; set; }
    public string DepartmentId { get; set; }
    public string ManagerId { get; set; }   
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Reason { get; set; }
    public string Statues { get; set; }
    public DateTime CreatedAt { get; set; }
    public UrgencyLevel UrgencyLevel { get; set; }      
}