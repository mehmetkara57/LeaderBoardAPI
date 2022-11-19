using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.Core.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        public string UserName { get; set; }

        public int Score { get; set; }
        public int Id { get; set; }
    }
}
