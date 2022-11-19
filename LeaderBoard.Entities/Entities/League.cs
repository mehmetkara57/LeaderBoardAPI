using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.Core.Entities
{
    public class League
    {
        public int Id { get; set; }
        public string LeagueName { get; set; }
    }
}
