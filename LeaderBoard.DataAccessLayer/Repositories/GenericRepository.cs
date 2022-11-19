using LeaderBoard.Core.Entities;
using LeaderBoard.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly LeaderBoardDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        private readonly DbSet<User> _user;
        public GenericRepository(LeaderBoardDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
            _user = _appDbContext.Set<User>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<List<User>> GetAll()
        {
            return await _user.OrderByDescending(x=> x.Score).ToListAsync();
        }

        public async Task<List<User>> GetAllByLeague(int leagueId)
        {
            return await _user.Where(x => x.LeagueId == leagueId).OrderByDescending(x=>x.Score).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        
    }
}
