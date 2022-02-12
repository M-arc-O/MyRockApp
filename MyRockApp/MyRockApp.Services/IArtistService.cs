using MyRockApp.Data.Models;

namespace MyRockApp.Services
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetAll();
        Artist GetById(int id);
        Artist GetByName(string name);
        void Add(Artist artist);
        void Update(Artist artist); 
        void Delete(int id);
    }
}
