using GameStore.DAL.DbContext;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly GameStoreContext _context;
        private bool _disposed = false;

        public GenreRepository(GameStoreContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }
        public async Task<Genre> GetAsync(int id)
        {
            return await _context.Genres.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Genre> AddAsync(Genre genre)
        {
            if (genre is null)
            {
                throw new ArgumentNullException(nameof(genre));
            }
            await _context.Genres.AddAsync(genre);
            return genre;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            bool isRemoved = false;
            var genre = await _context.Genres.FirstOrDefaultAsync(t => t.Id == id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                isRemoved = true;
            }
            return isRemoved;
        }

        protected virtual void Dispose(bool disposing)
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
