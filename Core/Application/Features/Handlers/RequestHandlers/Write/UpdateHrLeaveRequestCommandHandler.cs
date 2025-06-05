using Application.Features.Commands.RequestCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.RequestHandlers.Write;

public class UpdateHrLeaveRequestCommandHandler : IRequestHandler<UpdateHrLeaveRequestCommand>
{
    private readonly IRepository<LeaveRequest> _repository;

    public UpdateHrLeaveRequestCommandHandler(IRepository<LeaveRequest> repository)
    {
        _repository = repository;
    }
    
    
    public async Task Handle(UpdateHrLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Status = "IK Onayladi";       
        value.RejectionReason = "---";      
        await _repository.UpdateAsync(value);
        await _repository.SaveAsync();
    }
}