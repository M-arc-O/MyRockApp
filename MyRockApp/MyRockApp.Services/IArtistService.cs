using MyRockApp.Data.Models;

namespace MyRockApp.Services
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetAll();
        void Add(Artist artist);
    }
}
