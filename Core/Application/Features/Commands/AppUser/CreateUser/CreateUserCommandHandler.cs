using Application.Abstraction.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserServices _userServices;

        public CreateUserCommandHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _userServices.CreateAstnc(new()
            {
                NameSurename = request.NameSurename,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm
            });

            return new() { 
                isSuccess = result.isSuccess,
                Message = result.Message
            };

        }
    }
}
