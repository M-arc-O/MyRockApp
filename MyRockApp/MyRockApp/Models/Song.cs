using System.ComponentModel.DataAnnotations;

namespace MyRockApp.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MinLength(1)]
        public string Shortname { get; set; }

        [Required]
        public int Bpm { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [MinLength(1)]
        public string Genre { get; set; }

        [Required]
        public string SpotifyId { get; set; }

        [Required]
        public string Album { get; set; }
    }
}
