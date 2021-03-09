using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class SearchForPlayerViewModel
    {
        public string UserFirstVisit { get; set; }

        public string LastName { get; set;  }

        public string Position { get; set; }

        public int TeamID { get; set; }

        public int RookieYear { get; set; }

        public string FirstName { get; set; }

        public string TeamName { get; set; }

        public List<Player> ResultList { get; set; }
    }
}
