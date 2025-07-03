using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand>
{
    private readonly IRepository<PurchaseRequest>  _purchaseRepository;
    private readonly IRepository<PurchaseRequestItem> _itemRepository;

    public CreatePurchaseCommandHandler(
        IRepository<PurchaseRequest> purchaseRepository,
        IRepository<PurchaseRequestItem> itemRepository)
    {
        _purchaseRepository = purchaseRepository;
        _itemRepository = itemRepository;
    }
    
    public async Task Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = new PurchaseRequest
        {
            Id = Guid.NewGuid().ToString(),
            UserId = request.UserId,
            ManagerId = request.ManagerId,
            DepartmanId = request.DepartmentId,
            CreatedAt = DateTime.Now,
            UrgencyLevel = request.UrgencyLevel,
            Reason = request.Reason,
            Status = "Talep Alındı",
            Items = request.Items.Select(itemDto => new PurchaseRequestItem
            {
                Id = Guid.NewGuid().ToString(), // Eğer Id string ve Guid şeklinde ise
                ProductName = itemDto.ProductName,
                Quantity = itemDto.Quantity,
                Description = itemDto.Description
            }).ToList()
        };

        await _purchaseRepository.CreateAsync(purchase);
        await _purchaseRepository.SaveAsync();
    }

}