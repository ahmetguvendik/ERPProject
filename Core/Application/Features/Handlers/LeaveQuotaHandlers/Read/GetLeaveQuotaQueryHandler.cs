using Application.Features.Queries.LeaveQuotaQueries;
using Application.Features.Results.LeaveQuotaResults;
using Application.Repostitories;
using MediatR;

namespace Application.Features.Handlers.LeaveQuotaHandlers.Read;

public class GetLeaveQuotaQueryHandler : IRequestHandler<GetLeaveQuotaQuery, GetLeaveQuotaQueryResult>
{
    private readonly ILeaveQuotaRepository _leaveQuotaRepository;

    public GetLeaveQuotaQueryHandler(ILeaveQuotaRepository leaveQuotaRepository)
    {
         _leaveQuotaRepository = leaveQuotaRepository;
    }
    
    public async Task<GetLeaveQuotaQueryResult> Handle(GetLeaveQuotaQuery request, CancellationToken cancellationToken)
    {
        var value = await _leaveQuotaRepository.GetByUserIdAsync(request.Id);
        return new GetLeaveQuotaQueryResult
        {
            EmployeeId = value.EmployeeId,
            Year = value.Year,
            AllowedDays = value.AllowedDays,
            UsedDays = value.UsedDays,
        };
    }
}