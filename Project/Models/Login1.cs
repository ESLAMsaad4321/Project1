namespace Project.Models
{
    public class Login1
    {
        public string Emil { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; } 

        public byte[]?PasswordSalt { get; set; }

    }
}
