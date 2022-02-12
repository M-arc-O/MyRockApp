using MyRockApp.Data.Models;
using MyRockApp.Data.Repositories;

namespace MyRockApp.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private readonly MyRockAppDBContext _context;
        private GenericRepository<Artist> _artistRepository;
        private GenericRepository<Song> _songRepository;

        public IGenericRepository<Artist> ArtistRepository
        {
            get
            {
                if (_artistRepository == null)
                {
                    _artistRepository = new GenericRepository<Artist>(_context);
                }

                return _artistRepository;
            }
        }

        public IGenericRepository<Song> SongRepository
        {
            get
            {
                if (_songRepository == null)
                {
                    _songRepository = new GenericRepository<Song>(_context);
                }

                return _songRepository;
            }
        }

        public UnitOfWork(MyRockAppDBContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
