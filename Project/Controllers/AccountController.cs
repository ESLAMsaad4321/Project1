using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Services.EmployeeServices;

namespace Project.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _Context;
        public AccountController(IAccountServices context)
        {
            _Context = context; 
        }
     
        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAccounts()
        {
            return await _Context.GetAccounts();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountsById(int id)
        {
            var result = await _Context.GetAccountsById(id);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Account>>> AddAccount(Account account)
        {
            var result = await _Context.AddAccount(account);
            

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Account>>> UpdateAccount(int id,Account requist)
        {
            var result = await _Context.UpdateAccount(id,requist);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Account>>> DeleteAccount(int id)
        {
           var result = await _Context.DeleteAccount(id);
            if (result is null)
                return NotFound("Sorry Not Found");

            return Ok(result);
        }

    }
}
