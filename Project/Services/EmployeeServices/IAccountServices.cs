namespace Project.Services.EmployeeServices
{
    public interface IAccountServices
    {
        Task< List<Account>> GetAccounts();
        Task<Account> GetAccountsById(int id);
       Task<List<Account> >AddAccount(Account account);
       Task<List<Account>? >UpdateAccount(int id, Account requist);
        Task<List<Account>?> DeleteAccount(int id);

    }
}
