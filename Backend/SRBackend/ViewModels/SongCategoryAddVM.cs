
using Microsoft.AspNetCore.Http;
using System;

namespace SRBackend.ViewModels
{
    public class SongCategoryAddVM
    {

        public string Name { get; set; }
        public IFormFile CategoryPic { get; set; }

    }
}
