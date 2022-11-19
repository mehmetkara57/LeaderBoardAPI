using LeaderBoard.Core.DTOs.LeagueDTOs;
using LeaderBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.Core.DTOs.UserDTOs
{
    public class GetUserDTO : BaseDTO
    {
        public string UserName { get; set; }
        public int Score { get; set; }
        public LeagueType LeagueId { get; set; }


    }
    public enum LeagueType :int
    {
        GoldLeague=1,
        SilverLeague=2,
        BronzeLeague=3
    }
}
