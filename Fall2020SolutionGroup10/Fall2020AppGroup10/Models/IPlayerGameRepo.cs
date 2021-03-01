using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup10.Models
{
    public interface IPlayerGameRepo
    {
        List<PlayerGameDropDownViewModel> ListAllPlayerinGame(int gameID);
    }
}
