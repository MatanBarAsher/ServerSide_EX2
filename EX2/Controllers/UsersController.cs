using EX2.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EX2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public List<User> ReadUsers()
        {
            User u = new User();
            return u.ReadUsers();
        }
        //public IEnumerable<User> Get()
        //{
        //    User u = new User();
        //    return u.Read(); 
        //}

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public int Post([FromBody] User user)
        {
            return user.InsertUser();
        }

        [HttpPost]
        [Route("Login")]
        public User CheckLogin([FromBody] User user)
        {
            return user.CheckLogin();
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPut("update")]
        public int UpdateUser([FromBody] User updatedUser)
        {
            return updatedUser.UpdateUser(updatedUser.Email, updatedUser.FirstName, updatedUser.FamilyName, updatedUser.Password);
        }
    }
}
