using Domain.Models;

namespace ForSuccess.State.Accounts
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
