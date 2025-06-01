using Application.Features.Queries.AppUserQueries;
using Application.Features.Results.AppUserResults;
using Application.Repostitories;
using Domain.Enums;
using MediatR;

namespace Application.Features.Handlers.AppUserHandlers.Read;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,GetUserByIdQueryResult>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
         _userRepository = userRepository;
    }
    
    public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _userRepository.GetUserById(request.Id);
        return new GetUserByIdQueryResult   
        {
            Id = value.Id,
            TCNo = value.TCNo,
            FirstName = value.FirstName,
            LastName = value.LastName,
            BirthDate = value.BirthDate,
            Gender = value.Gender,
            PhoneNumber = value.PhoneNumber,
            StartingJob = value.StartingJob,
            DepartmanName = value.Departman.Name,
            JobTitle = value.JobTitle,
            JobTypeName = value.JobType.Name,
            SicilNo = value.SicilNo,
            BrutSalary = value.BrutSalary,
            NetSalary = value.NetSalary,
            Iban = value.Iban,
            Prim = value.Prim,
            Disruptions = value.Disruptions,
            IsActive = value.IsActive,
            ManagerName = value.Manager.FirstName + " " + value.Manager.LastName,
            UserName = value.UserName,
            
        };
    }
}