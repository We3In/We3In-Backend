using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        Dtos.Token CreateAccessToken(int hours);
    }
}
