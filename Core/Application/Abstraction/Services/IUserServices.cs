using Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface IUserServices
    {
        Task<CreateUserResponseDto> CreateAstnc(CreateUserDto model);
    }
}
