using Application.Features.Commands;
using Application.Features.Results.AppUserResults;
using Application.Repostitories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.AppUserHandlers.Write;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,LoginUserQueryResult>
{
    private readonly IUserRepository _userRepository;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    
    

    public LoginUserCommandHandler(IUserRepository userRepository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
         _userRepository = userRepository;
         _signInManager = signInManager;
         _userManager = userManager;
    }
    
    public async Task<LoginUserQueryResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByTcNo(request.TcNo);
        if (user != null)
        {
            var response = await _signInManager.PasswordSignInAsync(user,request.Password,false,false);
            if (response.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(user);
                if(role.Contains("Staff"))
                {
                    return new LoginUserQueryResult()
                    {
                        Id = user.Id,
                        TcNo = request.TcNo,
                        RoleName = "Staff",
                        ManagerId = user.ManagerId,
                    };
                }

                if (role.Contains("Manager"))
                {
                    return new LoginUserQueryResult()
                    {
                        Id = user.Id,
                        TcNo = request.TcNo,
                        RoleName = "Manager",
                        ManagerId = user.ManagerId,
                    };
                }
                
                if (role.Contains("HR"))
                {
                    return new LoginUserQueryResult()
                    {
                        Id = user.Id,
                        TcNo = request.TcNo,
                        RoleName = "HR",
                        ManagerId = user.ManagerId, 
                    };
                }
            }
        }

        return new LoginUserQueryResult()
        {
            Id = null,
            TcNo = null,
            RoleName = "User"
        };

    }
}