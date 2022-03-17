using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Videos.Stages
{
    public class Stage
    {
        public Stage(
            StageId id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public StageId Id { get; }
        public string Name { get; }
    }
}
