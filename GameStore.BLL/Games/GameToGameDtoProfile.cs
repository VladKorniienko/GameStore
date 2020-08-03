using AutoMapper;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Games
{
    public class GameToGameDtoProfile : Profile
    {
        public GameToGameDtoProfile()
        {
            CreateMap<Game, GameDto>().ReverseMap();
        }
    }
}
