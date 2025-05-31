using Application.Features.Handlers.AppRoleHandlers;
using Application.Features.Results.AppRoleResults;
using MediatR;

namespace Application.Features.Queries.AppRoleQueries;

public class GetManagerRoleQuery : IRequest<List<GetManagerRoleQueryResult>>
{
    
}