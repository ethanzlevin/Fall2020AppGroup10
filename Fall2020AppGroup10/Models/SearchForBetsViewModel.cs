using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class SearchForBetsViewModel
    {
        public string UserID { get; set; }

        public List<Bet> BetResultList { get; set; }


        public string FirstVisit { get; set; }

    }
}
