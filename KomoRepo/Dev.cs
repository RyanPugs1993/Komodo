using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoRepo
{
    public class Dev
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public bool HasPluralSightAccess { get; set; }

        public Dev() { }

        public Dev(string name, int id, bool hasPluralSightAccess)
        {
            Name = name;
            ID = id;
            HasPluralSightAccess = hasPluralSightAccess;
        }
    }
}
