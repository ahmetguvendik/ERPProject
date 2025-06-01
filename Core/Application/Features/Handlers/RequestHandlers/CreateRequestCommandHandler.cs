using Application.Features.Commands.RequestCommands;
using Application.Repostitories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.RequestHandlers;

public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand>
{
    private readonly IRepository<LeaveRequest>  _leaveRequestRepository;

    public CreateRequestCommandHandler(IRepository<LeaveRequest> leaveRequestRepository)
    {
         _leaveRequestRepository = leaveRequestRepository;
    }
    
    public async Task Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = new LeaveRequest();
        leaveRequest.Id = Guid.NewGuid().ToString();
        leaveRequest.CreatedAt = DateTime.Now;
        leaveRequest.Status = "Beklemede";
        leaveRequest.StartDate = request.StartDate;
        leaveRequest.EndDate = request.EndDate;
        leaveRequest.EmployeeId  = request.EmployeeId;
        leaveRequest.ManagerId   = request.ManagerId;
        leaveRequest.Type = request.RequestType;
        await _leaveRequestRepository.CreateAsync(leaveRequest);
        await _leaveRequestRepository.SaveAsync();
    }
}