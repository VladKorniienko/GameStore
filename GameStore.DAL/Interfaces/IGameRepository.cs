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
        Task<Game> AddAsync(Game game);
        Task<bool> AddGameGenreAsync(int gameId, int genreId);
        void Update (Game game);
        Task<bool> RemoveAsync(int id);
    }
}
