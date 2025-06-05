using Application.Features.Results.LeaveRequestResults;
using MediatR;

namespace Application.Features.Queries.LeaveRequestQueries;

public class GetLeaveRequestByApprovedQuery : IRequest<List<GetLeaveRequestByApprovedQueryResult>>
{
    
}