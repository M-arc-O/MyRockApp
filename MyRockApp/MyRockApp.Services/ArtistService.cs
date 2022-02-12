using MyRockApp.Data;
using MyRockApp.Data.Models;
using MyRockApp.Services.Exceptions;

namespace MyRockApp.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork; 

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Artist artist)
        {
            if (_unitOfWork.ArtistRepository.Get().Any(a=> a.Name.Equals(artist.Name)))
            {
                throw new DuplicateException();
            }

            _unitOfWork.ArtistRepository.Insert(artist);
            _unitOfWork.Save();
        }

        public IEnumerable<Artist> GetAll()
        {
            return _unitOfWork.ArtistRepository.Get();
        }
    }
}
