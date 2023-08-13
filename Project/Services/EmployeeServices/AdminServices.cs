/*
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Services.EmployeeServices
{
    public class AdminServices : IAdminServices
    {
        
            private readonly EsmContext _Context;

            public AdminServices(EsmContext context)
            {
                _Context = context;
            }
            public async Task <List <ActionResult<Login>>> Regestier(Login requist)
            {
            _Context.Logins.Add(requist);
            await _Context.SaveChangesAsync();
            return _Context.Logins.ToListAsync(); 

            }
    }
}

 
        private readonly EsmContext _Context;
        public static Login1 Login = new Login1();

        public AdminServices(EsmContext context)
        {
            _Context = context;
        }

        public async Task<List<Login1>> AddAccount(Login requist)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(requist.Password);
            Login.Emil = requist.Emil;

            Login.PasswordHash = passwordHash;
            _Context.Logins.Add() ;
            await _Context.SaveChangesAsync();
            return _Context.Logins.ToList();
        }

        public async Task<List<Login>?> DeleteAccount(int UserId)
        {
            var account = await _Context.Logins.FindAsync(UserId);
            if (account == null)
            {
                return null;
            }
            _Context.Logins.Remove(account);
            await _Context.SaveChangesAsync();

            return _Context.Logins.ToList();
        }

        public async Task<List<Login>> GetAccounts()
        {
            var account = await _Context.Logins.ToListAsync();
            return account;
        }

        public async Task<Login> GetAccountsById(int UserId)
        {
            var account = await _Context.Logins.FindAsync(UserId);
            if (account == null)
            {
                return null!;
            }
            return account;
        }

        public async Task<List<Login>?> UpdateAccount(int UserId, Login requist)
        {
            var account = await _Context.Logins.FindAsync(UserId);
            if (account == null)
            {
                return null;
            }
            account.Emil = requist.Emil;
            account.Password = requist.Password;
            account.UserId = requist.UserId;
            account.Security = requist.Security;
           
            _Context.Logins.Update(account);

            await _Context.SaveChangesAsync();
            return _Context.Logins.ToList();
        }
*/