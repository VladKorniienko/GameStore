using GameStore.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Genres
{
    public interface IGenreService
    {
        Task<ICollection<GenreDto>> GetAllAsync();
        Task<GenreDto> GetAsync(int id);
        Task<Genre> AddAsync(GenreDto game);
        Task<bool> Remove(int id);
    }
}
