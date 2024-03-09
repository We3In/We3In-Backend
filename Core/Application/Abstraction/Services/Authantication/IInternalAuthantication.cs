using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services.Authantication
{
    public interface IInternalAuthantication
    {
        Task LoginAsync(string emailOrPassword, string password);
    }
}
