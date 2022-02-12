using MyRockApp.Data.Models;

namespace MyRockApp.Services
{
    public interface ISongService
    {
        IEnumerable<Song> GetAll();
        void Add(Song song);
    }
}
