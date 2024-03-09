using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UserLoginFailedException : Exception
    {
        public UserLoginFailedException() : base("Invalid username or email")
        {
        }

        public UserLoginFailedException(string? message) : base(message)
        {
        }

        protected UserLoginFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
