using SRBackend.Data;
using SRBackend.Models;
using Microsoft.AspNetCore.Mvc;
using SRBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SRBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VoteRatingController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public VoteRatingController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.City.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserRatingAddVM x)
        {

            var newRating = new SongRating()
            {
             Song_id=x.SongID,
             User_id=x.UserID
            };

            SongRating check = null; check = _dbContext.SongRating.FirstOrDefault(s => s.Song_id == x.SongID && s.User_id == x.UserID);
            if (check != null) Ok("You cant vote twice!");

            var totalSongVotes = _dbContext.SongRating.Count(s => s.Song_id  == x.SongID);

            var Song = _dbContext.Song.FirstOrDefault(s => s.Id == x.SongID);

            var RatingNow = Song.SongRating;

            float NR = (RatingNow * totalSongVotes + x.Rating) / (totalSongVotes + 1);

            Song.SongRating = NR;
            _dbContext.Add(newRating);
            _dbContext.SaveChanges();
            return Ok(newRating);
        }


        [HttpGet]
        public ActionResult<List<SongRating>> GetAll()
        {

            var data = _dbContext.SongRating.ToList();
            return data;

        }
    }
}
