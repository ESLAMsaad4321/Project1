using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Logrequest
    {
     
            [Required, EmailAddress]
            public string Email { get; set; } = string.Empty;
            [Required]
            public string Password { get; set; } = string.Empty;
        
    }
}
