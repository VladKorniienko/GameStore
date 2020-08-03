using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Games
{
    public interface IGameService
    {
        Task<ICollection<GameDto>> GetAllAsync();
        Task<GameDto> GetAsync(int id);
    }
}
