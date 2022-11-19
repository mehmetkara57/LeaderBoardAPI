using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaderBoard.Core.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public int Score { get; set; }
        public int LeagueId { get; set; }
        
    }
}