using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.DAL.Interfaces
{
    public interface IGameRepository : IDisposable
    {
        Task<ICollection<Game>> GetAllAsync();
        Task<Game> GetAsync(int id);
    }
}
