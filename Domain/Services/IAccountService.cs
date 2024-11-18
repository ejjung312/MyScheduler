using Domain.Models;

namespace Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUserId(string userid);
    }
}
