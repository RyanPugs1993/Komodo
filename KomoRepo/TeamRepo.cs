using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoRepo
{
    public class TeamRepo
    {
            private List<Team> _Team = new List<Team>();



            public void AddTeamToList(Team teams)
            {
                _Team.Add(teams);
            }

            public List<Team> GetTeamList()
            {
                return _Team;
            }

            public Team GetTeamByID(int originId)
            {
                foreach (Team content in _Team)
                {
                    {
                        return content;
                    }
                }

                return null;
            }

            public bool RemoveTeamFromList(int Id)
            {
                Team team = GetTeamByID(Id);

                if (team == null)
                {
                    return false;
                }

                int initialCount = _Team.Count;
                _Team.Remove(team);

                if (initialCount > _Team.Count)
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

