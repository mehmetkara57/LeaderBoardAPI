using LeaderBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<User>> GetAll();
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void Remove(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(int id);
       Task< List<User>> GetAllByLeague(int leagueId);
    }
}
