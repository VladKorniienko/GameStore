using AutoMapper;
using GameStore.BLL.Games;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        // GET: api/games
        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _gameService.GetAllAsync();
            var gameViewModels = _mapper.Map<IEnumerable<GameViewModel>>(games);
            return Ok(gameViewModels);
        }

        // GET: api/games/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _gameService.GetAsync(id);

            var gameViewModel = _mapper.Map<GameViewModel>(game);

            if (gameViewModel == null)
            {
                return NotFound();
            }

            return Ok(gameViewModel);
        }
        //POST: api/games
        [HttpPost]
        public async Task<IActionResult> AddGame(GameViewModel gameViewModel)
        {
            if (gameViewModel is null)
            {
                throw new System.ArgumentNullException(nameof(gameViewModel));
            }

            var gameDto = _mapper.Map<GameDto>(gameViewModel);
            var result = await _gameService.AddAsync(gameDto);
            return Ok(result);
        }
        //DELETE: api/games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await _gameService.Remove(id);
            return Ok(result);
        }
    }
}
