using MyRockApp.Data.Models;
using System.Net;
using System.Text.Json;

namespace MyRockApp.Services
{
    public class InitializationService : IInitializationService
    {
        private readonly IArtistService _artistService;
        private readonly ISongService _songService;

        private const string _artistsFileName = "artists.json";

        public InitializationService(IArtistService artistService, ISongService songService)
        {
            _artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
            _songService = songService ?? throw new ArgumentNullException(nameof(songService));
        }

        public void Initialize()
        {
            var artistsFileName = "artists.json";
            var songsFileName = "songs.json";

            using var client = new WebClient();
            client.DownloadFile("https://raw.githubusercontent.com/Team-Rockstars-IT/MusicLibrary/v1.0/artists.json", artistsFileName);
            client.DownloadFile("https://raw.githubusercontent.com/Team-Rockstars-IT/MusicLibrary/v1.0/songs.json", songsFileName);

            List<Artist> artists = GetEntities<Artist>(artistsFileName);
            List<Song> songs = GetEntities<Song>(songsFileName);

            artists.ForEach(a =>
            {
                _artistService.Add(a);
            });
            songs.ForEach(s =>
            {
                _songService.Add(s);
            });
        }

        private List<T> GetEntities<T>(string fileName)
        {
            List<T> items = null;

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                items = JsonSerializer.Deserialize<List<T>>(json);
            }

            File.Delete(fileName);

            return items;
        }
    }
}
