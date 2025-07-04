using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Write;

public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IRepository<PurchaseRequest> _repository; 

    public UpdatePurchaseCommandHandler(IPurchaseRepository purchaseRepository, IRepository<PurchaseRequest> repository)
    {
        _purchaseRepository = purchaseRepository;
        _repository = repository;
    }
    
    public async Task Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var value = await _purchaseRepository.GetByIdWithItemsAsync(request.Id);

        if (value == null)
            throw new Exception("Satın alma isteği bulunamadı.");

        foreach (var itemDto in request.Items)
        {
            var existingItem = !string.IsNullOrEmpty(itemDto.Id)
                ? value.Items.FirstOrDefault(i => i.Id == itemDto.Id)
                : null;

            if (existingItem != null)
            {
                // Mevcut ürünü güncelle
                existingItem.ProductName = itemDto.ProductName;
                existingItem.Quantity = itemDto.Quantity;
                existingItem.Description = itemDto.Description;
            }
            else
            {
                // Yeni ürün ekle
                value.Items.Add(new PurchaseRequestItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductName = itemDto.ProductName,
                    Quantity = itemDto.Quantity,
                    Description = itemDto.Description
                });
            }
        }

        await _repository.UpdateAsync(value);
        await _repository.SaveAsync();
    }
}