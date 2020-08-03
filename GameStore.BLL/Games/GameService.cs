using AutoMapper;
using GameStore.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Games
{
    public class GameService : IGameService

    {
        private readonly IUnitOfWork _gameStore;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _gameStore = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<GameDto>> GetAllAsync()
        {
            var games = await _gameStore.GameRepository.GetAllAsync();
            var gameDtos = _mapper.Map<ICollection<GameDto>>(games);
            return gameDtos;
        }

        public async Task<GameDto> GetAsync(int id)
        {
            var game = await _gameStore.GameRepository.GetAsync(id);
            var gameDto = _mapper.Map<GameDto>(game);
            return gameDto;
        }

    }
}
