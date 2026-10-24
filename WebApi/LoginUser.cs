using System.ComponentModel.DataAnnotations;

namespace WebApi
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
