using AutoMapper;
using GameStore.BLL.Games;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostGame(GameViewModel gameViewModel)
        {
            if (gameViewModel is null)
            {
                throw new System.ArgumentNullException(nameof(gameViewModel));
            }

            var gameDto = _mapper.Map<GameDto>(gameViewModel);
            var result = await _gameService.AddAsync(gameDto);
            return Ok(result);
        }
        //POST: api/games/5/1
        [HttpPost("{gameId:int}/genres/{genreId:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostGameGenre(int gameId, int genreId)
        {
            var result = await _gameService.AddGameGenreAsync(gameId, genreId);
            if (result == true)
                return Ok(result);
            else
                return BadRequest();
        }
        //PUT: api/games
        [HttpPut]
        public async Task<IActionResult> PutGame(GameViewModel gameViewModel)
        {
            return Ok(await _gameService.UpdateAsync(_mapper.Map<GameDto>(gameViewModel)));
        }
        //DELETE: api/games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await _gameService.Remove(id);
            if (result == true)
                return Ok();
            else
                return BadRequest("Can`t find a game with this Id");
        }
    }
}
