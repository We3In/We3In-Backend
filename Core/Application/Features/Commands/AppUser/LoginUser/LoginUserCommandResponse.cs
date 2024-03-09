using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }

    public class LoginUserCommandSuccessResponse : LoginUserCommandResponse
    {
        public LoginUserCommandSuccessResponse(Token token)
        {
            Token = token;
        }
    }   

    public class LoginUserCommandFailedResponse : LoginUserCommandResponse
    {
        public string ErrorMessage { get; set; }

        public LoginUserCommandFailedResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
