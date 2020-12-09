using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer
{
    class Team
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public bool HasPluralSightAccess { get; set; }

        public Team() { }

        public Team(string name, int id, bool hasPluralSightAccess)
        {
            Name = name;
            ID = id;
            HasPluralSightAccess = hasPluralSightAccess;
        }
    }
}
