using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRockApp.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IInitializationService, InitializationService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<ISongService, SongService>();
        }
    }
}
