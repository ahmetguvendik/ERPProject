using Application.Features.Commands;
using Application.Features.Results.AppUserResults;
using Application.Repostitories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.AppUserHandlers.Write;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserQueryResult>
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
            var response = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (response.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);

                return new LoginUserQueryResult()
                {
                    Id = user.Id,
                    TcNo = request.TcNo,
                    RoleNames = roles.ToList(), // Artık liste olarak dönüyor
                    ManagerId = user.ManagerId,
                    DepartmanId = user.DepartmanId,
                };
            }
        }

        return new LoginUserQueryResult()
        {
            Id = null,
            TcNo = null,
            RoleNames = new List<string> { "User" },
            ManagerId = null,
            DepartmanId = null,
        };
    }
}