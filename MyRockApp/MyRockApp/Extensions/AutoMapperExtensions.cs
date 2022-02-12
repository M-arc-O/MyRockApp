using AutoMapper;
using MyRockApp.Models.MappingProfiles;

namespace MyRockApp.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {   // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ArtistMappingProfile());
                mc.AddProfile(new SongMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
