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
        public bool Add([FromBody] UserRatingAddVM x)
        {

            var newRating = new SongRating()
            {
             Song_id=x.SongID,
             User_id=x.UserID
            }; 

            SongRating check = null; check = _dbContext.SongRating.FirstOrDefault(s => s.Song_id == x.SongID && s.User_id == x.UserID);
            if (check != null) return false;//provjera da li je korisnik vec glasao za pjesmu, u slucaju da jest vraca false

            var totalSongVotes = _dbContext.SongRating.Count(s => s.Song_id  == x.SongID);//prebrojava broj korisnika koji su do sad glasali za pjesmu

            var Song = _dbContext.Song.FirstOrDefault(s => s.Id == x.SongID); //spremamo pjesmu

            var RatingNow = Song.SongRating; //dobijamo trenutni rating

            float NR = (RatingNow * totalSongVotes + x.Rating) / (totalSongVotes + 1); //definicija za izracun novog ratinga

            Song.SongRating = NR; //dodavanje nove vrijendosti
            _dbContext.Add(newRating);
            _dbContext.SaveChanges();
            return true;
        }


        [HttpGet]
        public ActionResult<List<SongRating>> GetAll()
        {

            var data = _dbContext.SongRating.ToList();
            return data;

        }
    }
}
