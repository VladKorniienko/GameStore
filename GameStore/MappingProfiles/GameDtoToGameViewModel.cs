using AutoMapper;
using GameStore.BLL.Games;
using GameStore.ViewModels;

namespace GameStore.MappingProfiles
{
    public class GameDtoToGameViewModel : Profile
    {
        public GameDtoToGameViewModel()
        {
            CreateMap<GameDto, GameViewModel>().ReverseMap();
        }
    }
}
