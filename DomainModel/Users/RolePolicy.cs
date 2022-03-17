using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Users
{
    public static class RolePolicy
    {
        private static Dictionary<Role, List<Tuple<Aggregate, UseCase>>> Policies = new Dictionary<Role, List<Tuple<Aggregate, UseCase>>>
        {
            {
                Role.Editor,
                new List<Tuple<Aggregate, UseCase>>
                {
                    new Tuple<Aggregate, UseCase>(Aggregate.Channel, UseCase.Add),
                    new Tuple<Aggregate, UseCase>(Aggregate.Video, UseCase.Add),
                }
            },
            {
                Role.Maintainer,
                new List<Tuple<Aggregate, UseCase>>
                {
                    new Tuple<Aggregate, UseCase>(Aggregate.Channel, UseCase.Add),
                    new Tuple<Aggregate, UseCase>(Aggregate.Channel, UseCase.Remove),
                    new Tuple<Aggregate, UseCase>(Aggregate.Video, UseCase.Add),
                    new Tuple<Aggregate, UseCase>(Aggregate.Video, UseCase.Remove),
                }
            },
        };

        public static bool CanDo(Role role, Aggregate aggregate, UseCase useCase)
        {
            var myPolicies = Policies[role];

            var canDo = myPolicies.Contains(new Tuple<Aggregate, UseCase>(aggregate, useCase));
            return canDo;
        }

    }
}
