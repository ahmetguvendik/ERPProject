using Application.Features.Queries.AppRoleQueries;
using Application.Features.Results.AppRoleResults;
using Application.Repostitories;
using MediatR;

namespace Application.Features.Handlers.AppRoleHandlers;

public class GetRoleQueryHandler  : IRequestHandler<GetRoleQuery, List<GetRoleQueryResult>>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleQueryHandler(IRoleRepository roleRepository)
    {
         _roleRepository = roleRepository;
    }
    public async Task<List<GetRoleQueryResult>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var values = await _roleRepository.GetAllAsync();
        return values.Select(x => new GetRoleQueryResult()
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}