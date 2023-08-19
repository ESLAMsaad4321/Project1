using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class AccountViewModel
    {
        public string Name { get; set; } = null!;
        [Key]
        public int Id { get; set; }
        [DisplayName("National id")]
        public string? Nationalid { get; set; }
        [DisplayName("Date of birth ")]
        public DateTime Dateofbirth { get; set; }

        public string Language { get; set; } = null!;
        [DisplayName("Language level")]

        public string Languagelevel { get; set; } = null!;

        public string Account1 { get; set; } = null!;
        [DisplayName("Line of business")]

        public string? Lineofbusiness { get; set; }
    }
}
