using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Users.Exceptions
{
    public class UserIsBannedUserException : Exception
    {
        public UserIsBannedUserException(string userId, string message) : base(message)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
