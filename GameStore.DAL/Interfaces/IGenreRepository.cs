using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.DAL.Interfaces
{
    public interface IGenreRepository : IDisposable
    {
        Task<ICollection<Genre>> GetAllAsync();
        Task<Genre> GetAsync(int id);
        Task<Genre> AddAsync(Genre genre);
        Task<bool> RemoveAsync(int id);
    }
}
