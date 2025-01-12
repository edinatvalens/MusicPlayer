﻿using SRBackend.Data;
using SRBackend.Models;
using Microsoft.AspNetCore.Mvc;
using SRBackend.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SRBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public FavoritesController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Favorites.FirstOrDefault(s => s.UserID == id));
        }

        [HttpPost]
        public bool Add([FromBody] FavoritesAddVM x)
        {
            Favorites check = null;
            check= _dbContext.Favorites.FirstOrDefault(a => a.SongID == x.SongID && a.UserID == x.UserID);
            if (check != null) return false; //provjera da li je korisnik vec dodao bas tu pjesmu u favorite... ako jest vraca false

            var newFav = new Favorites()
            {
                UserID = x.UserID,
                SongID = x.SongID
                
            };
            //dodavanje nove favorite pjesme
            _dbContext.Add(newFav);
            _dbContext.SaveChanges();
            return true;
        }


        [HttpGet]
        public IActionResult GetbyUser(int id)
        {

            return Ok(_dbContext.Favorites.Include(s => s.song).Include(s => s.song.songcategory).Where(a => a.UserID == id));

        }

        [HttpDelete]
        public ActionResult Delete(int idU, int idS)
        {
           
            Favorites fav = _dbContext.Favorites.FirstOrDefault(s=> s.UserID==idU && s.SongID==idS);//lociranje favorita za korisnika

            if (fav == null)
                return BadRequest("Incorrect ID");//provjera da li postoji

            _dbContext.Remove(fav);//brisanje favorita
            _dbContext.SaveChanges();
            return Ok(fav);
        }
    }
}
