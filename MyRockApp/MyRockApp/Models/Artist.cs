using System.ComponentModel.DataAnnotations;

namespace MyRockApp.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required]
        [MinLength(1)] 
        public string Name { get; set; }
    }
}
