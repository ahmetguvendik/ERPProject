using Application.Features.Queries.LeaveRequestQueries;
using Application.Features.Results.LeaveRequestResults;
using Application.Repostitories;
using Domain.Enums;
using MediatR;

namespace Application.Features.Handlers.RequestHandlers.Read;

public class GetLeaveRequestByManagerIdQueryHandler : IRequestHandler<GetLeaveRequestByManagerIdQuery,List<GetLeaveRequestByManagerIdQueryResult>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestByManagerIdQueryHandler(ILeaveRequestRepository leaveRequestRepository)
    {
         _leaveRequestRepository = leaveRequestRepository;
    }
    
    public async Task<List<GetLeaveRequestByManagerIdQueryResult>> Handle(GetLeaveRequestByManagerIdQuery request, CancellationToken cancellationToken)
    {
       var values = await _leaveRequestRepository.GetByManagerIdAsync(request.Id);
       return values.Select(x=> new  GetLeaveRequestByManagerIdQueryResult
       {
           EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,
           ManagerId = x.ManagerId,
           StartDate = x.StartDate,
           EndDate = x.EndDate,
           Type = x.Type,
           Status = x.Status,
           RejectionReason = x.RejectionReason,
           CreatedAt = x.CreatedAt,
       }).ToList();
    }
}
