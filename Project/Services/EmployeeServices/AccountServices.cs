using Microsoft.EntityFrameworkCore;

namespace Project.Services.EmployeeServices
{
    public class AccountServices : IAccountServices
    {
        private readonly EsmContext _Context;

        public AccountServices(EsmContext context)
        {
            _Context= context  ;
        }

        public async Task< List<Account> >AddAccount(Account account)
        {
            _Context.Accounts.Add(account);
            await _Context.SaveChangesAsync();
            return _Context.Accounts.ToList();
        }

        public async Task< List<Account>?> DeleteAccount(int id)
        {
            var account = await _Context.Accounts.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            _Context.Accounts.Remove(account);
            await _Context.SaveChangesAsync();

            return _Context.Accounts.ToList();
        }

        public async Task< List<Account>> GetAccounts()
        {
            var account = await _Context.Accounts.ToListAsync();
            return account;
        }

        public async Task< Account> GetAccountsById(int id)
        {
            var account = await _Context.Accounts.FindAsync(id);
            if (account == null)
            {
                return null!;
            }
            return account;
        }

        public async Task< List<Account>?>UpdateAccount(int id, Account requist)
        {
            var account = await _Context.Accounts.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            account.Name = requist.Name;
            account.Id = requist.Id;
            account.Dateofbirth= requist.Dateofbirth;
            account.Nationalid = requist.Nationalid;
            account.Language= requist.Language;
            account.Languagelevel = requist.Languagelevel;
            account.Account1= requist.Account1;
            account.Lineofbusiness= requist.Lineofbusiness;
            _Context.Accounts.Update(account);

            await _Context.SaveChangesAsync();
            return _Context.Accounts.ToList(); 
        }
    }
}
