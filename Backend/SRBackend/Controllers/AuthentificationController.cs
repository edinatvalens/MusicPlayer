using SRBackend.Helper;
using SRBackend.Helper.AutentifikacijaAutorizacija;
using SRBackend.Data;
using SRBackend.Models;
using SRBackend.ModelsAutentififkacija;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using static SRBackend.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;

namespace SRBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public AuthentificationController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        {

            UserProfile logiraniKorisnik = _dbContext.UserProfile
                .FirstOrDefault(k => k.Username != null && k.Username == x.username && k.Password == x.password);//nalazimo usera

            if(logiraniKorisnik == null)//provjeravamo da li postoji
            {
                return null;
            }

            string randomString = TokenGenerator.Generate(10);//pravimo random string od 10 karaktera

            var noviToken = new AutentifikacijaToken()
            {
                ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                vrijednost = randomString,
                korisnickiNalog = logiraniKorisnik,
                vrijemeEvideniranja = DateTime.Now
            }; //dodjeljujemo token

            _dbContext.Add(noviToken);//dodajemo token u bazu
            _dbContext.SaveChanges();

            return new LoginInformacije(noviToken);
        }

        [HttpPost]
        public ActionResult Logout()
        {

            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return Ok("It was null!");

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return Ok("Succes!");
        }

        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {

            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            return autentifikacijaToken;
        }


    }
}
