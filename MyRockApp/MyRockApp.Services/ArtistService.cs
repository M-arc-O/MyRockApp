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

        public IEnumerable<Artist> GetAll()
        {
            return _unitOfWork.ArtistRepository.Get();
        }

        public Artist GetById(int id)
        {
            return _unitOfWork.ArtistRepository.GetByID(id);
        }

        public Artist GetByName(string name)
        {
            return _unitOfWork.ArtistRepository.Get(a => a.Name.Equals(name)).FirstOrDefault();
        }

        public void Add(Artist artist)
        {
            CheckForDuplicate(artist);

            _unitOfWork.ArtistRepository.Insert(artist);
            _unitOfWork.Save();
        }

        public void Update(Artist artist)
        {
            Artist oldArtist = GetAndCheckIfExists(artist.ArtistId);

            CheckForDuplicate(artist);

            oldArtist.Name = artist.Name;

            _unitOfWork.ArtistRepository.Update(oldArtist);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            GetAndCheckIfExists(id);

            _unitOfWork.ArtistRepository.Delete(id);
            _unitOfWork.Save();
        }

        private Artist GetAndCheckIfExists(int id)
        {
            var oldArtist = _unitOfWork.ArtistRepository.GetByID(id);
            if (oldArtist == null)
            {
                throw new NotFoundException();
            }

            return oldArtist;
        }

        private void CheckForDuplicate(Artist artist)
        {
            if (_unitOfWork.ArtistRepository.Get().Any(a => a.Name.ToUpper().Equals(artist.Name.ToUpper())))
            {
                throw new DuplicateException();
            }
        }
    }
}
