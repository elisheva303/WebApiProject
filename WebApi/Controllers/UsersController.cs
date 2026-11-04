using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;
using Service;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<Users>

        IUserServic usersService ;

        public UsersController(IUserServic usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        static  readonly string filePath = "text.txt";

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
         
            return "value";
        }

        // POST api/<Users>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User postUser)
        {
            postUser=usersService.AddUser(postUser);
            return CreatedAtAction(nameof(Get), new { id = postUser.Id }, postUser);
        }
        [HttpPost("Login")]
        public ActionResult<User> Post([FromBody] LoginUser loginUser)
        {

            User user = usersService.GetUser(loginUser);
            if (user == null)
                return NotFound();
            return Ok(user);

        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User userUpdate)
        {
          usersService.UpdateUser(id, userUpdate);
            return Ok();
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
