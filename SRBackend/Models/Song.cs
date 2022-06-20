using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SRBackend.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public string ArtristName { get; set; }
        public string SongUrl { get; set; }
        public string SongRating { get; set; }
        public bool Favorite { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime EditDate { get; set; }

        [ForeignKey(nameof(songcategory))]
        public int Song_Category_id { get; set; }
        public SongCategory songcategory { get; set; }
       
    }
}
