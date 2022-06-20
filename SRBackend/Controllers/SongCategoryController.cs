using SRBackend.Data;
using Microsoft.AspNetCore.Mvc;
using SRBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using SRBackend.Models;

namespace SRBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SongCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SongCategoryController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.SongCategory.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public SongCategory Add([FromBody] SongCategoryAddVM x)
        {

            var newCategory = new SongCategory()
            {
                Name = x.Name,

            };

            _dbContext.Add(newCategory);
            _dbContext.SaveChanges();
            return newCategory;
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] SongCategoryAddVM x)
        {

            SongCategory katetgorija = _dbContext.SongCategory.FirstOrDefault(s => s.Id == id);

            if (katetgorija == null)
                return BadRequest("Pogresan ID");

            katetgorija.Name = x.Name;

            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<SongCategory>> GetAll(string Name)
        {

            var data = _dbContext.SongCategory.Where(x => Name == null || (x.Name)
            .StartsWith(Name))
                .OrderByDescending(s => s.Name).ThenByDescending(s => s.Name)
                .AsQueryable();

            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            SongCategory category = _dbContext.SongCategory.Find(id);

            if (category == null)
                return BadRequest("Incorrect ID");

            _dbContext.Remove(category);
            _dbContext.SaveChanges();
            return Ok(category);
        }
    }
}
