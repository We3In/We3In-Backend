using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services.Authantication
{
    public interface IInternalAuthantication
    {
        Task<Dtos.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<Dtos.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
