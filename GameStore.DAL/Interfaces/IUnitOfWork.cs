using System;
using System.Threading.Tasks;

namespace GameStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository GameRepository { get; }
        IGenreRepository GenreRepository { get; }
        Task SaveAsync();
    }
}
