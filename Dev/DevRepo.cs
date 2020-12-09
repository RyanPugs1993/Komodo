using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer
{
    public class DevRepo
    {
        public List<Dev> _dev = new List<Dev>();



        public void AddDeveloperToList(Dev dev)
        {
            _dev.Add(dev);
        }

        public List<Dev> GetDeveloperList()
        {
            return _dev;
        }

         public bool UpdateExistingDevelopers(int originId, Dev newDeveloper)
        {
            Dev oldDeveloper = GetDeveloperByID(originId);

            if (oldDeveloper != null)

            {
                oldDeveloper.ID = newDeveloper.ID;
                oldDeveloper.Name = newDeveloper.Name;
                oldDeveloper.HasPluralSightAccess = newDeveloper.HasPluralSightAccess;

                return true;
            }
            else
            {
                return false;
            }

        }

        private Dev GetDeveloperByID(int originId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDeveloperFromList(string Id)
        {
            Dev dev = GetDeveloperByID(Id);

            if(dev == null)
            {
                return false;
            }

            int initialCount = _dev.Count;
            _dev.Remove(dev);

            if (initialCount > _dev.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Dev GetDeveloperByID(string originId)
        {
            throw new NotImplementedException();
        }
    }
}
