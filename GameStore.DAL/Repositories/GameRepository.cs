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
            return await _context.Games.Include(g => g.GameGenres).ThenInclude(gg => gg.Genre).ToListAsync();
        }
        public async Task<Game> GetAsync(int id)
        {
            return await _context.Games.Include(g => g.GameGenres).ThenInclude(gg => gg.Genre).FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<bool> AddGameGenreAsync(int gameId, int genreId)
        {

            bool isAdded = false;
            var game = await _context.Games.Include(g => g.GameGenres).ThenInclude(gg => gg.Genre).FirstOrDefaultAsync(g => g.Id == gameId);
            var genre = await _context.Genres.FirstOrDefaultAsync(gn => gn.Id == genreId);
            if (game != null && genre != null)
            {
                GameGenre gameGenre = new GameGenre
                {
                    Game = game,
                    Genre = genre
                };
                await _context.GameGenres.AddAsync(gameGenre);
                isAdded = true;
            }
            return isAdded;
        }

        public async Task<Game> AddAsync(Game game)
        {
            if (game is null)
            {
                throw new ArgumentNullException(nameof(game));
            }
            await _context.Games.AddAsync(game);
            return game;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            bool isRemoved = false;
            var game = await _context.Games.FirstOrDefaultAsync(t => t.Id == id);
            if (game != null)
            {
                _context.Games.Remove(game);
                isRemoved = true;
            }
            return isRemoved;

        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                _disposed = true;
            }

        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
