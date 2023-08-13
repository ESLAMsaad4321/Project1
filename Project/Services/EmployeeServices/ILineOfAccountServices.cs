namespace Project.Services.EmployeeServices
{
    public interface ILineOfAccountServices
    {
        Task<List<LineOfAccount>> GetAccounts();
        Task<LineOfAccount> GetAccountsById(int id);
        Task<List<LineOfAccount>> AddAccount(LineOfAccount account);
        Task<List<LineOfAccount>?> UpdateAccount(int id, LineOfAccount requist);
        Task<List<LineOfAccount>?> DeleteAccount(int id);
    }
}
