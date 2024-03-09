using Application.Abstraction.Services;
using Application.Abstraction.Token;
using Application.Dtos;
using Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;
        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
            return new LoginUserCommandSuccessResponse(token);
        }
    }
}
