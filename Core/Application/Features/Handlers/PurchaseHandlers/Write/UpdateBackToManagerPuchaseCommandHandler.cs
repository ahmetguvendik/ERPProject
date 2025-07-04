using Application.Features.Commands.PurchaseCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.PurchaseHandlers.Write;

public class UpdateBackToManagerPuchaseCommandHandler : IRequestHandler<UpdateBackToManagerPuchaseCommand>
{
    private readonly IRepository<PurchaseRequest> _repository;

    public UpdateBackToManagerPuchaseCommandHandler(IRepository<PurchaseRequest> repository)
    {
         _repository = repository;
    }
    
    public async Task Handle(UpdateBackToManagerPuchaseCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Status = "Talep Alındı";
        await _repository.UpdateAsync(value);
        await _repository.SaveAsync();
    }
}