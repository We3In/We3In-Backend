using Application.Abstraction.Services;
using Application.Dtos.User;
using Application.Features.Commands.AppUser.CreateUser;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Services
{
    public class UserServices : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserServices(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDto> CreateAstnc(CreateUserDto model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                NameSurname = model.NameSurename,
                Email = model.Email,
            }, model.Password);

            if (result.Succeeded)
            {
                return new CreateUserResponseDto
                {
                    isSuccess = true,
                    Message = "User created successfully"
                };
            }
            else
            {
                return new CreateUserResponseDto
                {
                    isSuccess = false,
                    Message = string.Join(", ", result.Errors.Select(x => x.Description))
                };
            }
        }
    }
}
