using AutoMapper;

namespace MyRockApp.Models.MappingProfiles
{
    public class SongMappingProfile : Profile
    {
        public SongMappingProfile()
        {
            CreateMap<Song, MyRockApp.Data.Models.Song>();
            CreateMap<MyRockApp.Data.Models.Song, Song>();
        }
    }
}
