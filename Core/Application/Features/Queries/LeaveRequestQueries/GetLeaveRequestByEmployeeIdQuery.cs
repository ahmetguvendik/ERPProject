using Application.Features.Results.LeaveRequestResults;
using MediatR;

namespace Application.Features.Queries.LeaveRequestQueries;

public class GetLeaveRequestByEmployeeIdQuery : IRequest<List<GetLeaveRequestByEmployeeIdQueryResult>>
{
    public string EmployeeId { get; set; }

    public GetLeaveRequestByEmployeeIdQuery(string employeeId)
    {
         EmployeeId = employeeId;
    }
}