using AutoMapper;
using GameStore.DAL.Entities;
using GameStore.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Genres
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _gameStore;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _gameStore = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Genre> AddAsync(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _gameStore.GenreRepository.AddAsync(genre);
            await _gameStore.SaveAsync();
            return genre;
        }

        public async Task<ICollection<GenreDto>> GetAllAsync()
        {
            var genres = await _gameStore.GenreRepository.GetAllAsync();
            var genreDtos = _mapper.Map<ICollection<GenreDto>>(genres);
            return genreDtos;
        }

        public async Task<GenreDto> GetAsync(int id)
        {
            var genre = await _gameStore.GenreRepository.GetAsync(id);
            var genreDto = _mapper.Map<GenreDto>(genre);
            return genreDto;
        }

        public async Task<bool> Remove(int id)
        {
            bool isRemoved = false;
            if (await _gameStore.GenreRepository.RemoveAsync(id))
                isRemoved = true;
            await _gameStore.SaveAsync();
            return isRemoved;
        }
    }
}
