using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        public static Login1 Login = new Login1();
        private readonly IConfiguration _configuration;
        private readonly EsmContext _Context;


        public AdminController(IConfiguration configuration, EsmContext context)
        {

            _configuration = configuration;
            _Context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Regestier(log requist)
        {
            if (_Context.Logins.Any(u => u.Emil == requist.Email))
            {
                return BadRequest("User already exists.");
            }
            var count = 1;
            CreatePasswordHash(requist.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            Login.Emil= requist.Email;
            Login.PasswordHash= passwordHash;
            Login.PasswordSalt= passwordSalt;
            
            var res = new Login();
            
            res.Emil = requist.Email;
            res.Password = requist.Password;
            res.UserId = count++;
            res.Security = passwordSalt;
            res.PasswordHash = passwordHash;
            res.PasswordSalt = passwordSalt;
            _Context.Logins.Add(res);
            await _Context.SaveChangesAsync();
            return Ok(Login);
        }
        [HttpPost("login")]
       
        public async Task<IActionResult> log(Logrequest requist)
        {
            var user = await _Context.Logins.FirstOrDefaultAsync(u => u.Emil == requist.Email);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            if (!VerifyPasswordHash(requist.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect.");
            }
            string Token = CreateToken(requist);
            return Ok(Token);
        }

        private string CreateToken(Logrequest tok)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,tok.Email),
  
            };
          
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var creds = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenItem = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(10), //temprarly for now
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
    );
            var JWT = new JwtSecurityTokenHandler().WriteToken(tokenItem);
            return (JWT);
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
        
      