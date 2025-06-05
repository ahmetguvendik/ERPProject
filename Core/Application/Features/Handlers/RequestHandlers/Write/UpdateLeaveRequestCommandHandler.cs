using Application.Features.Commands.RequestCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.RequestHandlers.Write;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand>
{
    private readonly IRepository<LeaveRequest> _repository;

    public UpdateLeaveRequestCommandHandler(IRepository<LeaveRequest> repository)
    {
         _repository = repository;
    }
    
    public async Task Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Status = "Onaylandi";
        value.RejectionReason = "Izin Onaylandi";   
        await _repository.UpdateAsync(value);
        await _repository.SaveAsync();
    }
}