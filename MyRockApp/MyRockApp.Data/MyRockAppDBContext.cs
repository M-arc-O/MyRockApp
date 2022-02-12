using Microsoft.EntityFrameworkCore;
using MyRockApp.Data.Models;

namespace MyRockApp.Data
{
    public class MyRockAppDBContext : DbContext
    {
        public MyRockAppDBContext(DbContextOptions<MyRockAppDBContext> options)
            : base(options)
        {

        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}
