using SRBackend.Data;
using SRBackend.Models;
using SRBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SRBackend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            return Ok(_dbContext.User.Include(i => i.city).Include(i => i.gender).FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public User Add([FromBody] UserAddVM x)
        {

            var ckeck= _dbContext.User.FirstOrDefault(s => s.Username == x.Username && s.Password == x.Password);

            if (ckeck == null)
            {

                var newUser = new User()
                {

                    Name = x.Name,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    Birthdate = x.Birthdate,
                    Adress = x.Adress,
                    City_id = x.City_id,
                    Gender_id = x.Gender_id,
                    Username = x.Username,
                    Password = x.Password,

                };

                _dbContext.Add(newUser);
                _dbContext.SaveChanges();
                return newUser;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public  ActionResult<List<User>> GetAll2()
        {

            var country =  _dbContext.User.Include(i => i.city).Include(i=>i.gender).ToList();
            return country;

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
  
            User user = _dbContext.User.Find(id);

            if (user == null)
                return BadRequest("Incorrect ID");

            _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return Ok(user);
        }
    }
}
