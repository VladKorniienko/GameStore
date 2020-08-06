using AutoMapper;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Genres
{
    public class GenreToGenreDtoProfile : Profile
    {
        public GenreToGenreDtoProfile()
        {
            CreateMap<Genre, GenreDto>().ReverseMap();
        }
    }
}
