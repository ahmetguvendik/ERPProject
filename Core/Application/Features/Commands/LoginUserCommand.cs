using Application.Features.Results.AppUserResults;
using MediatR;

namespace Application.Features.Commands;

public class LoginUserCommand : IRequest<LoginUserQueryResult>
{
    public string TcNo { get; set; }
    public string Password { get; set; }
}