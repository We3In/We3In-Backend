using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userId);
        bool ValidateJwtToken(string token);
    }
}
