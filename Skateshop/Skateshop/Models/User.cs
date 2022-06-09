using System.ComponentModel.DataAnnotations;

namespace Skateshop.Models
{
    public class User
    {

        public long Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

    }
}
