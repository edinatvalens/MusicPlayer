using Microsoft.AspNetCore.Http;
using System;

namespace SRBackend.ViewModels
{
    public class ArtikalAddVM
    {
        public string SongName { get; set; }
        public string ArtristName { get; set; }
        public string SongUrl { get; set; }
        public string SongRating { get; set; }
        public bool Favorite { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime EditDate { get; set; }
        public int SongCategoryID { get; set; }

    }
}
