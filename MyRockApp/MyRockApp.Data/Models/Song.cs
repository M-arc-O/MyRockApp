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

        public int? Bpm { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Genre { get; set; }

        public string? SpotifyId { get; set; }

        public string? Album { get; set; }

        [Required]
        public string Artist { get; set; }
    }
}
