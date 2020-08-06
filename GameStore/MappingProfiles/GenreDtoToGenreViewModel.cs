using AutoMapper;
using GameStore.BLL.Genres;
using GameStore.ViewModels;

namespace GameStore.MappingProfiles
{
    public class GenreDtoToGenreViewModel : Profile
    {
         public GenreDtoToGenreViewModel()
        {
            CreateMap<GenreDto, GenreViewModel>().ReverseMap();
        }
    }
}
