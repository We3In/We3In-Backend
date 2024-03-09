using Application.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Services
{
    public class AuthServices : IAuthService
    {
        public Task LoginAsync(string emailOrPassword, string password)
        {
            throw new NotImplementedException();
        }
    }
}
