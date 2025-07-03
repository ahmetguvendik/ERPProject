using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Commands.PurchaseCommands;

public class CreatePurchaseCommand : IRequest
{
    public string UserId { get; set; }
    public string ManagerId { get; set; }
    public string DepartmentId { get; set; }
    public UrgencyLevel UrgencyLevel { get; set; }
    public string Reason { get; set; }
    public List<PurchaseRequestItemDto> Items { get; set; }   
}