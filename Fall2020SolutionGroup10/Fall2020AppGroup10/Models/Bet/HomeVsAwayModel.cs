using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public class HomeVsAwayModel
    {
        public int GameID { get; set; }

        public string HomeName { get; set; }

        public string AwayName { get; set; }

        public string GameName
        {
            get
            {
                return (HomeName + " Vs. " + AwayName);
            }

        }
    }
}
