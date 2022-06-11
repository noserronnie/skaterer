using System.ComponentModel.DataAnnotations;

namespace Skaterer.Services.Auth.Models
{
    public class LoginViewModel
    {

        [Required]
        public string Identifier { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
