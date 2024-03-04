using Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                NameSurname = request.NameSurename,
                Email = request.Email,
            }, request.Password);

            if(result.Succeeded)
            {
                return new CreateUserCommandResponse
                {
                    isSuccess = true,
                    Message = "User created successfully"
                };
            }
            else
            {
                return new CreateUserCommandResponse
                {
                    isSuccess = false,
                    Message = string.Join(", ", result.Errors.Select(x => x.Description))
                };
            }


        }
    }
}
