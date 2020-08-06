using AutoMapper;
using GameStore.BLL.Genres;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        // GET: api/genres
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _genreService.GetAllAsync();
            var genreViewModels = _mapper.Map<IEnumerable<GenreViewModel>>(genres);
            return Ok(genreViewModels);
        }

        // GET: api/genres/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre(int id)
        {
            var genre = await _genreService.GetAsync(id);

            var genreViewModel = _mapper.Map<GenreViewModel>(genre);

            if (genreViewModel == null)
            {
                return NotFound();
            }

            return Ok(genreViewModel);
        }
        //POST: api/genres
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddGenre(GenreViewModel genreViewModel)
        {
            if (genreViewModel is null)
            {
                throw new System.ArgumentNullException(nameof(genreViewModel));
            }

            var genreDto = _mapper.Map<GenreDto>(genreViewModel);
            var result = await _genreService.AddAsync(genreDto);
            return Ok(result);
        }
        //DELETE: api/genres/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var result = await _genreService.Remove(id);
            if (result == true)
                return Ok(result);
            else
                return BadRequest("Can`t find a genre with this Id");
        }
    }
}
