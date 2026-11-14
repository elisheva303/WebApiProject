using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;
//fix: removed the duplicate using Service; line



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

        //The assignment asks GET by id to return the user with this id, or NotFound / NoContent if there is none: how would you read the user from the file?
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
                //The assignment asks a login with a wrong password to return 204 NoContent: what should this return instead of NotFound?
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
