using GameStore.DAL.DbContext;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameStoreContext _context;
        private bool _disposed = false;
        public GameRepository(GameStoreContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(t => t.Id == id);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
