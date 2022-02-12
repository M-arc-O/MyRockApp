using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRockApp.Data;

namespace MyRockApp.Services.Extensions
{
    public static class DBExtensions
    {
        public static void AddDBContext(this IServiceCollection services)
        {
            services.AddDbContext<MyRockAppDBContext>(opt => opt.UseInMemoryDatabase("MyRockApp"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}
