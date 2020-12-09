using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoRepo
{
    public class Team
    {
        public string Name { get; set; }

        public int ID { get; set; }
        public string Teams { get; set; }

        public string Dragon  { get; set; }

        public string Snake { get; set; }

        public Team() { }
        public Team(string teams)
        {
            Teams = teams;
        }

        public Team(string name, int id, string dragon, string snake)
        {
            Name = name;
            ID = id;
            Dragon = dragon;
            Snake = snake;
        }
    }
}
