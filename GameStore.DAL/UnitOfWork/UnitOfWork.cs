using GameStore.DAL.DbContext;
using GameStore.DAL.Interfaces;
using GameStore.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace GameStore.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGameRepository _gameRepository;
        private bool _disposed = false;
        public UnitOfWork(GameStoreContext context)
        {
            this.Context = context;
        }

        public GameStoreContext Context { get; set; }

        public IGameRepository GameRepository
        {
            get
            {
                return _gameRepository = _gameRepository ?? new GameRepository(Context);
            }
        }
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context?.Dispose();
                    GameRepository?.Dispose();
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
