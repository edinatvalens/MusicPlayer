using SRBackend.Data;
using SRBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using SRBackend.ViewModels;

namespace SRBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IWebHostEnvironment webHostEnvironment;
        
        private IHttpContextAccessor httpContextAccessor;

        public SongController(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment, IHttpContextAccessor _httpContextAccessor)
        {

            this._dbContext = dbContext;
            webHostEnvironment = hostEnvironment;
            httpContextAccessor = _httpContextAccessor;

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Song.Include(kp => kp.songcategory)
               .FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public Song Add([FromForm] SongAddVM x)
        {
            
            var newSong = new Song()
            {
                SongName=x.SongName,
                ArtristName=x.ArtristName,
                SongUrl=x.SongUrl,
                SongRating=0,
                AddedDate=x.AddedDate,
                EditDate=x.EditDate,
                Song_Category_id=x.SongCategoryID
            };

       
            _dbContext.Song.Add(newSong);
            _dbContext.SaveChanges();
            return newSong;
        }

        [HttpGet]
        public ActionResult<List<Song>> GetAll()
        {

            var data = _dbContext.Song.Include(kp => kp.songcategory).ToList();
            return data;

        }
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {

            Song song = _dbContext.Song.Find(id);

            if (song == null)
             return BadRequest("Incorrect ID");

            _dbContext.Remove(song);
            _dbContext.SaveChanges();
            return Ok(song);

        }

        [HttpGet("{id}")]
        public IActionResult GetPoKategoriji(int id)
        {
            return Ok(_dbContext.Song.Include(kp => kp.songcategory).Where(kp => kp.Song_Category_id == id));
        }
    }
}
