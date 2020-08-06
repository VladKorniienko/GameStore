using AutoMapper;
using GameStore.BLL.Games;
using GameStore.ViewModels;
using System.Linq;

namespace GameStore.MappingProfiles
{
    public class GameDtoToGameViewModel : Profile
    {
        public GameDtoToGameViewModel()
        {
            CreateMap<GameDto, GameViewModel>().ForMember(dto => dto.Genres, g => g.MapFrom(g => g.Genres)).ReverseMap();
        }
    }
}
