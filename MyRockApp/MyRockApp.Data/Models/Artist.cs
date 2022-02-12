using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRockApp.Data.Models
{
    [Table("Artists")]
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Song> Songs { get; set; }
    }
}
