using System.ComponentModel.DataAnnotations;

namespace LogicSolution.Model
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
