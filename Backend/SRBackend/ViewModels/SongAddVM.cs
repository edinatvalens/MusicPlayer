using Microsoft.AspNetCore.Http;
using System;

namespace SRBackend.ViewModels
{
    public class SongAddVM
    {
        public string SongName { get; set; }
        public string ArtristName { get; set; }
        public string SongUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime EditDate { get; set; }
        public int SongCategoryID { get; set; }

    }
}
