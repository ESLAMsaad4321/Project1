using Microsoft.AspNetCore.Mvc;
using Project.Services.EmployeeServices;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelOfLanguageController : Controller
    {
        private readonly ILevelOfLanguageServices _Context;
        public LevelOfLanguageController(ILevelOfLanguageServices context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<LevelOfLanguage>>> GetAccounts()
        {
            return await _Context.GetAccounts();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelOfLanguage>> GetAccountsById(int id)
        {
            var result = await _Context.GetAccountsById(id);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<LevelOfLanguage>>> AddAccount(LevelOfLanguage account)
        {
            var result = await _Context.AddAccount(account);


            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<LevelOfLanguage>>> UpdateAccount(int id, LevelOfLanguage requist)
        {
            var result = await _Context.UpdateAccount(id, requist);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<LevelOfLanguage>>> DeleteAccount(int id)
        {
            var result = await _Context.DeleteAccount(id);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }
    }
}
