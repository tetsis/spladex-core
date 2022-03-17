using DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Users.Exceptions
{
    public class UserIsNotAuthorizedException : Exception
    {
        public UserIsNotAuthorizedException(Role role, Aggregate aggregate, UseCase useCase, string message) : base(message)
        {
            Role = role;
            Aggregate = aggregate;
            UseCase = useCase;
        }

        public Role Role { get; }
        public Aggregate Aggregate { get; }
        public UseCase UseCase { get; }
    }
}
