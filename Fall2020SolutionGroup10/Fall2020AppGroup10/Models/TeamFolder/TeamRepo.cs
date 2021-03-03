using Fall2020AppGroup10.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class TeamRepo : ITeamRepo
    {
        private ApplicationDbContext database;

        public TeamRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public int AddTeam(Team team)
        {
            database.Team.Add(team);
            database.SaveChanges();
            return team.TeamID;
        }

        public void DeleteTeam(Team team)
        {
            database.Team.Remove(team);
            database.SaveChanges();
        }

        public void EditTeam(Team team)
        {
            database.Team.Update(team);
            database.SaveChanges();
        }

        public Team FindTeam(int? teamID)
        {
            Team team = database.Team.Find(teamID);
            return team;
        }

        public List<Team> ListAllTeams()
        {
            List<Team> teams = database.Team.Include(p => p.PlayersOnTeam).ToList();
            return teams;
        }
    }
}
