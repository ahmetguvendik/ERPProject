using Application.Features.Queries.LeaveRequestQueries;
using Application.Features.Results.LeaveRequestResults;
using Application.Repostitories;
using Domain.Enums;
using MediatR;

namespace Application.Features.Handlers.RequestHandlers.Read;

public class GetLeaveRequestByApprovedQueryHandler : IRequestHandler<GetLeaveRequestByApprovedQuery, List<GetLeaveRequestByApprovedQueryResult>>
{
    private readonly ILeaveRequestRepository _repository;

    public GetLeaveRequestByApprovedQueryHandler(ILeaveRequestRepository repository)
    {
         _repository = repository;
    }
    
    public async Task<List<GetLeaveRequestByApprovedQueryResult>> Handle(GetLeaveRequestByApprovedQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByApprovedAsync();
        return values.Select(x => new GetLeaveRequestByApprovedQueryResult
        {
            Id = x.Id,
            EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,
            ManagerName = x.Manager.FirstName + " " + x.Manager.LastName,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            Type = x.Type,
            Status = x.Status,
            RejectionReason = x.RejectionReason,
            CreatedAt = x.CreatedAt 
        }).ToList();
    }
}