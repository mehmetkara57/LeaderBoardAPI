using LeaderBoard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.DataAccessLayer
{
    public class LeaderBoardDbContext:DbContext
    {
        public LeaderBoardDbContext(DbContextOptions<LeaderBoardDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<League> Leagues { get; set; }

    }
}
