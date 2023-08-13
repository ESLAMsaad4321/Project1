namespace Project.Services.EmployeeServices
{
    public class LevelOfLanguageServices : ILevelOfLanguageServices
    {
        private readonly EsmContext _Context;

        public LevelOfLanguageServices(EsmContext context)
        {
            _Context = context;
        }

        public async Task<List<LevelOfLanguage>> AddAccount(LevelOfLanguage account)
        {
            _Context.LevelOfLanguages.Add(account);
            await _Context.SaveChangesAsync();
            return _Context.LevelOfLanguages.ToList();
        }

        public async Task<List<LevelOfLanguage>?> DeleteAccount(int id)
        {
            var account = await _Context.LevelOfLanguages.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            _Context.LevelOfLanguages.Remove(account);
            await _Context.SaveChangesAsync();

            return _Context.LevelOfLanguages.ToList();
        }

        public async Task<List<LevelOfLanguage>> GetAccounts()
        {
            var account = await _Context.LevelOfLanguages.ToListAsync();
            return account;
        }

        public async Task<LevelOfLanguage> GetAccountsById(int id)
        {
            var account = await _Context.LevelOfLanguages.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            return account;
        }

        public async Task<List<LevelOfLanguage>?> UpdateAccount(int id, LevelOfLanguage requist)
        {
            var account = await _Context.LevelOfLanguages.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            account.Id = requist.Id;
            account.Language = requist.Language;
            account.Languagelevel = requist.Languagelevel;
            _Context.LevelOfLanguages.Update(account);

            await _Context.SaveChangesAsync();
            return _Context.LevelOfLanguages.ToList();
        }
    }
}

