using Application.Features.Queries.LeaveRequestQueries;
using Application.Features.Results.LeaveRequestResults;
using Application.Repostitories;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace Application.Features.Handlers.RequestHandlers.Read;

public class GetLeaveRequestByEmployeeIdQueryHandler : IRequestHandler<GetLeaveRequestByEmployeeIdQuery, List<GetLeaveRequestByEmployeeIdQueryResult>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestByEmployeeIdQueryHandler(ILeaveRequestRepository leaveRequestRepository)
    {
         _leaveRequestRepository = leaveRequestRepository;
    }
    
    public async Task<List<GetLeaveRequestByEmployeeIdQueryResult>> Handle(GetLeaveRequestByEmployeeIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _leaveRequestRepository.GetByEmployeeIdAsync(request.EmployeeId);
        return values.Select(x => new GetLeaveRequestByEmployeeIdQueryResult
        {
            Id = x.Id,
            EmployeeId = x.EmployeeId,
            ManagerName = x.Manager != null ? x.Manager.FirstName + " " + x.Manager.LastName : null,    
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            Type = x.Type,
            Status = x.Status,
            RejectionReason = x.RejectionReason,
            CreatedAt = x.CreatedAt,
            
        }).ToList();;
    }
}