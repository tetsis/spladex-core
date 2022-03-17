using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Users.Exceptions
{
    public class UserIsNotAuthenticatedException : Exception
    {
        public UserIsNotAuthenticatedException(string userId, string message) : base(message)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
