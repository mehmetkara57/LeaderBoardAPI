using LeaderBoard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoard.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<List<User>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<User>> GetAllByLeagueAsync(int LeagueId);
    }
}
