using MyRockApp.Data;
using MyRockApp.Data.Models;
using MyRockApp.Services.Exceptions;

namespace MyRockApp.Services
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Song song)
        {
            if (_unitOfWork.SongRepository.Get().Any(s =>
                s.Name.Equals(song.Name) &&
                s.Artist.Equals(song.Artist)))
            {
                throw new DuplicateException();
            }

            _unitOfWork.SongRepository.Insert(song);
            _unitOfWork.Save();
        }

        public IEnumerable<Song> GetAll()
        {
            return _unitOfWork.SongRepository.Get();
        }
    }
}
