using System.ComponentModel.DataAnnotations;

namespace MyRockApp.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
