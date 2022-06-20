
using System.ComponentModel.DataAnnotations.Schema;


namespace SRBackend.Models
{

    public class Favorites
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(song))]
        public int SongID { get; set; }
        public Song song { get; set; }

    }
}
