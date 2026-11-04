using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class LoginUser
    {
       // [Required]
       // public int Id { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
//namespace Entities
//{
//    public class User
//{
//    public int Id { get; set; }

//    [Required]
//    public string Email { get; set; }

//    [Required]
//    public string FirstName { get; set; }

//    [Required]
//    public string LastName { get; set; }

//    [Required]
//    public string Password { get; set; }
//}
//}