using Application.Features.Commands.RequestCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.RequestHandlers.Write;

public class UpdateRejectLeaveRequestCommandHandler : IRequestHandler<UpdateRejectLeaveRequestCommand>
{
    private readonly IRepository<LeaveRequest> _repository;

    public UpdateRejectLeaveRequestCommandHandler(IRepository<LeaveRequest> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateRejectLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Status = "Reddedildi";
        value.RejectionReason = request.RejectionReason;
        await _repository.UpdateAsync(value);
        await _repository.SaveAsync();
    }
}