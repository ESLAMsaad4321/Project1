using Microsoft.AspNetCore.Mvc;
using Project.Services.EmployeeServices;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineOfAccountController : Controller
    {
        private readonly ILineOfAccountServices _Context;
        public LineOfAccountController(ILineOfAccountServices context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<LineOfAccount>>> GetAccounts()
        {
            return await _Context.GetAccounts();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LineOfAccount>> GetAccountsById(int id)
        {
            var result = await _Context.GetAccountsById(id);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<LineOfAccount>>> AddAccount(LineOfAccount account)
        {
            var result = await _Context.AddAccount(account);


            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<LineOfAccount>>> UpdateAccount(int id, LineOfAccount requist)
        {
            var result = await _Context.UpdateAccount(id, requist);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<LineOfAccount>>> DeleteAccount(int id)
        {
            var result = await _Context.DeleteAccount(id);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }
    }
}
