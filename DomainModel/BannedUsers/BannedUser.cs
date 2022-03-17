using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.BannedUsers
{
    public class BannedUser
    {
        public BannedUser(
            string id,
            string name,
            string image)
        {
            Id = id;
            Name = name;
            Image = image;
            CreateTime = DateTime.Now;
        }

        public string Id { get; }
        public string Name { get; }
        public string Image { get; }
        public DateTime CreateTime { get; }
    }
}
