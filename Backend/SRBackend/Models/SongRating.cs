
using System.ComponentModel.DataAnnotations.Schema;

namespace SRBackend.Models
{
    public class SongRating
    {
        public int Id { get; set; }

        [ForeignKey(nameof(song))]
        public int Song_id { get; set; }
        public Song song { get; set; }
        public int User_id { get; set; }
    }
}
