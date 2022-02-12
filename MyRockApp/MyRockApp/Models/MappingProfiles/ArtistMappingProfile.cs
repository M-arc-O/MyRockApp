using AutoMapper;

namespace MyRockApp.Models.MappingProfiles
{
    public class ArtistMappingProfile : Profile
    {
        public ArtistMappingProfile()
        {
            CreateMap<Artist, MyRockApp.Data.Models.Artist>();
            CreateMap<MyRockApp.Data.Models.Artist, Artist>();
        }
    }
}
