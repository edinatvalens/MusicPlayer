using SRBackend.Data;
using SRBackend.Models;
using SRBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SRBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public GenderController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Gender.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public Gender Add([FromBody] GenderAddVM x)
        {

            var newGender = new Gender()
            {
                Name = x.Name,

            };

            _dbContext.Add(newGender);
            _dbContext.SaveChanges();
            return newGender;
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] GenderAddVM x)
        {


            Gender spol = _dbContext.Gender.FirstOrDefault(s => s.Id == id);

            if (spol == null)
                return BadRequest("Incorrect ID");

            spol.Name = x.Name;

            _dbContext.SaveChanges();
            return Get(id);
        }
        [HttpGet]
        public ActionResult<List<Gender>> GetAll()
        {

            var data = _dbContext.Gender
                .AsQueryable();

            return data.Take(100).ToList();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Gender gender = _dbContext.Gender.Find(id);

            if (gender == null)
                return BadRequest("Incorrect ID");

            _dbContext.Remove(gender);
            _dbContext.SaveChanges();
            return Ok(gender);
        }
    }
}
