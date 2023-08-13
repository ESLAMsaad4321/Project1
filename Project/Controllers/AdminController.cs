using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        public static Login1 Login = new Login1();
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {

            _configuration = configuration;
        }
      
            [HttpPost("register")]
        public ActionResult<Login1> Regestier(Login requist)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(requist.Password);

            Login.Emil = requist.Emil;

            Login.PasswordHash = passwordHash;



            return Ok(Login);
        }
        [HttpPost("login")]
        public ActionResult<Login1> log(Login requist)
        {
            if (Login.Emil != requist.Emil)
            {
                return BadRequest("Wrong Email");
            }

            if (!BCrypt.Net.BCrypt.Verify(requist.Password,Login.PasswordHash))
            {
                return BadRequest("Wrong Password");
            }
            string Token =CreateToken(Login);
            return Ok(Token);
        }
        private string CreateToken(Login1 tok)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,tok.Emil),
  
            };
            /*
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var Token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds);
            var JWT =new JwtSecurityTokenHandler().WriteToken(Token);
            return (JWT);
            */
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

        /*
         [HttpGet]
         public async Task<ActionResult<List<Login>>> GetAccounts()
         {
             return await _Context.GetAccounts();
         }
         [HttpGet("{UserId}")]
         public async Task<ActionResult<Login>> GetAccountsById(int UserId)
         {
             var result = await _Context.GetAccountsById(UserId);
             if (result is null)
                 return NotFound("Sorry Not Found");

             return Ok(result);
         }

         [HttpPut("{UserId}")]
         public async Task<ActionResult<List<Login>>> UpdateAccount(int UserId, Login requist)
         {
             var result = await _Context.UpdateAccount(UserId, requist);
             if (result is null)
                 return NotFound("Sorry Not Found");

             return Ok(result);
         }
         [HttpDelete("{UserId}")]

         public async Task<ActionResult<List<Login>>> DeleteAccount(int UserId)
         {
             var result = await _Context.DeleteAccount(UserId);
             if (result is null)
                 return NotFound("Sorry Not Found");

             return Ok(result);
         }
        */


    }
 }
        
      