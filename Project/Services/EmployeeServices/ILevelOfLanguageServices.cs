namespace Project.Services.EmployeeServices
{
    public interface ILevelOfLanguageServices
    {
        Task<List<LevelOfLanguage>> GetAccounts();
        Task<LevelOfLanguage> GetAccountsById(int id);
        Task<List<LevelOfLanguage>> AddAccount(LevelOfLanguage account);
        Task<List<LevelOfLanguage>?> UpdateAccount(int id, LevelOfLanguage requist);
        Task<List<LevelOfLanguage>?> DeleteAccount(int id);
    }
}
