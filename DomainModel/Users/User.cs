using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Users
{
    public class User
    {
        public User(
            string id,
            string name,
            string image,
            string oauthToken,
            string oauthTokenSecret,
            Role role)
        {
            Id = id;
            Name = name;
            Image = image;
            OauthToken = oauthToken;
            OauthTokenSecret = oauthTokenSecret;
            SessionId = Guid.NewGuid().ToString();
            Role = role;
        }

        public string Id { get; }

        public string Name { get; private set; }
        public string Image { get; private set; }

        public string OauthToken { get; private set; }
        public string OauthTokenSecret { get; private set; }
        public string SessionId { get; private set; }

        public Role Role { get; private set; }

        public void ChangeProperties(string name, string image)
        {
            Name = name;
            Image = image;
        }

        public void ChangeTokens(string oauthToken, string oauthTokenSecret)
        {
            OauthToken = oauthToken;
            OauthTokenSecret = oauthTokenSecret;
        }

        public void SetSessionId()
        {
            SessionId = Guid.NewGuid().ToString();
        }

        public void Logout()
        {
            SessionId = "";
        }

        public void ChangeRole(Role role)
        {
            Role = role;
        }

        public bool Auth(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId)) return false;
            if (sessionId != SessionId) return false;
            return true;
        }

        public bool CanDo(Aggregate aggregate, UseCase useCase)
        {
            // Viewerは権限がない
            if (Role == Role.Viewer) return false;

            // Administratorは全ての権限がある
            if (Role == Role.Administrator) return true;

            var canDo = RolePolicy.CanDo(Role, aggregate, useCase);
            return canDo;
        }
    }
}
