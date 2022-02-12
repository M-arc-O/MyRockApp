using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRockApp.Data.Models
{
    [Table("Songs")]
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Shortname { get; set; }

        [Required]
        public int Bpm { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string SpotifyId { get; set; }

        [Required]
        public string Album { get; set; }

        public Artist Artist { get; set; }
    }
}
