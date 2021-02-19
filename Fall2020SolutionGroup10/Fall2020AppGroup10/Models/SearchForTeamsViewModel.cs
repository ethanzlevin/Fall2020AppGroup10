using System.Collections.Generic;

namespace Fall2020AppGroup10.Models
{
    public class SearchForTeamsViewModel
    {

        public int? TeamID { get; set; }

        public int? TeamID1 { get; set; }
        
        public string Name { get; set; }
        public string City { get; set; }
        public string Division { get; set; }
        
        
        public int? MinWins { get; set; }
        public int? MaxWins { get; set; }

        public int? MinLosses { get; set; }
        public int? MaxLosses { get; set; }

        public string UserFirstVisit { get; set; }

        public List<Team> ResultTeamList { get; set; }
    }
}
