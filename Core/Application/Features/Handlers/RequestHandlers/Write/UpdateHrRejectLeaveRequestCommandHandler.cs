using Application.Features.Commands.RequestCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.RequestHandlers.Write;

public class UpdateHrRejectLeaveRequestCommandHandler : IRequestHandler<UpdateHrRejectLeaveRequestCommand>
{
    private readonly IRepository<LeaveRequest> _repository;

    public UpdateHrRejectLeaveRequestCommandHandler(IRepository<LeaveRequest> repository)
    {
        _repository = repository;
    }
    

    public async Task Handle(UpdateHrRejectLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Status = "IK Reddetti";
        value.RejectionReason = request.RejectionReason;      
        await _repository.UpdateAsync(value);
        await _repository.SaveAsync();
    }
}