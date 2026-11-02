using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApi.Models;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //fix: A controller class name ends with Controller. The route stays api/Users.
    //fix: The file is renamed to UsersController.cs, so it matches the class
    public class UsersController : ControllerBase
    {
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //fix: The path never changes, so it can be readonly
        static readonly string filePath = "text.txt";

        // GET api/<Users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))

            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.Id == id)
                        return Ok(user);
              
                }
            }

            return NotFound();
        }

        // POST api/<Users>
        [HttpPost]
        //In C#, parameters are written in camelCase (postUser)
        public ActionResult<User> Post([FromBody] User PostUser)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            PostUser.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(PostUser);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return Ok(PostUser);
        }
        [HttpPost("Login")]
        public ActionResult<User> Post([FromBody] LoginUser loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == loginUser.Email && user.Password==loginUser.Password)
                        return Ok(user);
                }
            }
            return NoContent();

        
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end.
        //In C#, parameters are written in camelCase (userUpdate)
        public void Put(int id, [FromBody] User userupdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if(textToReplace != string.Empty)
{
                //fix: Keep the id, otherwise the updated user is saved without it
                userupdate.Id = id;
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userupdate));
                System.IO.File.WriteAllText(filePath, text);
            }
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
