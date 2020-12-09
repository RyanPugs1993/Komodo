using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomDev
{

    public enum IdNum
    {
        four = 1,
        six,
        twenty,
        thirtythree,

    }

    //POCO DEV
    public class KomDev
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public bool HasPluralSightAccess { get; set; }

        public IdNum NumberID { get; set; }

        public KomDev() { }

        public KomDev(string name, int id, bool hasPluralSightAccess, IdNum ident)
        {
            Name = name;
            ID = id;
            HasPluralSightAccess = hasPluralSightAccess;
            NumberID = ident;

        }
    }
}
