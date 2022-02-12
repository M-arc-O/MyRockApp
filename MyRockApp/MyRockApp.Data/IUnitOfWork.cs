using MyRockApp.Data.Models;
using MyRockApp.Data.Repositories;

namespace MyRockApp.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<Artist> ArtistRepository { get; }
        IGenericRepository<Song> SongRepository { get; }

        void Dispose();
        void Save();
        Task<int> SaveAsync();
    }
}