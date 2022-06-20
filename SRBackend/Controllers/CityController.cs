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
    public class CityController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CityController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.City.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public City Add([FromBody] CityAddVM x)
        {

            var newcity = new City()
            {
                Name = x.Name,
                PostalNumber = x.Postal
                
            };

            _dbContext.Add(newcity);
            _dbContext.SaveChanges();
            return newcity;
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] CityAddVM x)
        {
           

            City grad = _dbContext.City.FirstOrDefault(s => s.Id == id);

            if (grad == null)
                return BadRequest("Incorrect ID!");

            grad.Name = x.Name;
            grad.PostalNumber = x.Postal;
        
            _dbContext.SaveChanges();
            return Get(id);
        }

        [HttpGet]
        public ActionResult<List<City>> GetAll(string Name)
        {

            var data = _dbContext.City.Where(x => Name == null || (x.Name)
            .StartsWith(Name))
                .OrderByDescending(s => s.Name).ThenByDescending(s => s.Name)
                .AsQueryable();
            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           
            City city = _dbContext.City.Find(id);

            if (city == null)
                return BadRequest("Incorrect ID");

            _dbContext.Remove(city);
            _dbContext.SaveChanges();
            return Ok(city);
        }
    }
}
