namespace Project.Services.EmployeeServices
{
    public class LineOfAccountServices:ILineOfAccountServices
    {
        private readonly EsmContext _Context;

        public LineOfAccountServices(EsmContext context)
        {
            _Context = context;
        }

        public async Task<List<LineOfAccount>> AddAccount(LineOfAccount account)
        {
            _Context.LineOfAccounts.Add(account);
            await _Context.SaveChangesAsync();
            return _Context.LineOfAccounts.ToList();
        }

        public async Task<List<LineOfAccount>?> DeleteAccount(int id)
        {
            var account = await _Context.LineOfAccounts.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            _Context.LineOfAccounts.Remove(account);
            await _Context.SaveChangesAsync();

            return _Context.LineOfAccounts.ToList();
        }

        public async Task<List<LineOfAccount>> GetAccounts()
        {
            var account = await _Context.LineOfAccounts.ToListAsync();
            return account;
        }

        public async Task<LineOfAccount> GetAccountsById(int id)
        {
            var account = await _Context.LineOfAccounts.FindAsync(id);
            if (account == null)
            {
                return null!;
            }
            return account;
        }

        public async Task<List<LineOfAccount>?> UpdateAccount(int id, LineOfAccount requist)
        {
            var account = await _Context.LineOfAccounts.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            account.Id = requist.Id;
            account.Account = requist.Account;
            account.Lineofbusiness = requist.Lineofbusiness;
            _Context.LineOfAccounts.Update(account);

            await _Context.SaveChangesAsync();
            return _Context.LineOfAccounts.ToList();
        }
    }
}
