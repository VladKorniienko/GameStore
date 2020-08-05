using AutoMapper;
using GameStore.DAL.Entities;
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

        public async Task<Game> AddAsync(GameDto gameDto)
        {
           
            var game = _mapper.Map<Game>(gameDto);
            await _gameStore.GameRepository.AddAsync(game);
            await _gameStore.SaveAsync();
            return game;
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

        public async Task<bool> Remove(int id)
        {
            var isRemoved = _gameStore.GameRepository.RemoveAsync(id);
            await _gameStore.SaveAsync();
            return await isRemoved;
        }
    }
}
