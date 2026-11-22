using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;
//fix: Removed the duplicate using Service; line, it was already at the top




namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<Users>

        IUserServic usersService ;

        //The assignment asks the users controller to take IPasswordService and call it: which constructor parameter will you add for it?
        public UsersController(IUserServic usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
         
            return "value";
        }

        // POST api/<Users>
        [HttpPost]
        //The assignment asks POST to return 400 for a weak password: where do you check the strength before AddUser?
        public async Task<ActionResult<User>> Post([FromBody] User postUser)
        {
             postUser=await usersService.AddUser(postUser);
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
        public async Task<IActionResult> Put(int id, [FromBody] User userUpdate)
        {
            //The assignment asks PUT to return 400 for a weak password: where do you check the strength before UpdateUser?
            await usersService.UpdateUser(id, userUpdate);
            return Ok();
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
