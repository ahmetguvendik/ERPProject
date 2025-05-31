using System.Runtime.CompilerServices;
using Application.Features.Queries.AppRoleQueries;
using Application.Features.Results.AppRoleResults;
using Application.Repostitories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.AppRoleHandlers;

public class GetManagerRoleQueryHandler  : IRequestHandler<GetManagerRoleQuery, List<GetManagerRoleQueryResult>>
{
    private readonly UserManager<AppUser>  _userManager;

    public GetManagerRoleQueryHandler(UserManager<AppUser> userManager)
    {
         _userManager = userManager;
    }
    
    public async Task<List<GetManagerRoleQueryResult>> Handle(GetManagerRoleQuery request, CancellationToken cancellationToken)
    {
        var usersInManagerRole = await _userManager.GetUsersInRoleAsync("Manager");

        return usersInManagerRole.Select(x => new GetManagerRoleQueryResult()
        {
            Id = x.Id,
            Name = x.FirstName + " " + x.LastName,
        }).ToList();
    }
}