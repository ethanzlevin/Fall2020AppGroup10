using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public interface ITeamRepo
    {
        List<Team> ListAllTeams();

        int AddTeam(Team team);
        void EditTeam(Team team);
        Team FindTeam(int? teamID);
        void DeleteTeam(Team team);
    }
}
