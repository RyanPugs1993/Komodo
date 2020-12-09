using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoRepo
{

    public class DevRepo
    {
        private List<Dev> _dev = new List<Dev>();



        public void AddDeveloperToList(Dev dev)
        {
            _dev.Add(dev);
        }

        public List<Dev> GetDeveloperList()
        {
            return _dev;
        }
        
        public Dev GetDeveloperByID(int originId)
        {
            foreach (Dev content in _dev)
            {
                {
                    return content;
                }
            }

            return null;
        }

        public bool RemoveDeveloperFromList(int Id)
        {
            Dev dev = GetDeveloperByID(Id);

            if (dev == null)
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
    }
         
    
}
