using AutoMapper;
using GameStore.DAL.Entities;
using System.Linq;

namespace GameStore.BLL.Games
{
    public class GameToGameDtoProfile : Profile
    {
        public GameToGameDtoProfile()
        {
           // CreateMap<Game, GameGenreDto>().ForMember(dto => dto.Genres, g => g.MapFrom(g => g.GameGenres.Select(gg => gg.Genre))).ReverseMap();
            CreateMap<Game, GameDto>().ForMember(dto => dto.Genres, g => g.MapFrom(g => g.GameGenres.Select(gg => gg.Genre))).ReverseMap();

        }
    }
}
