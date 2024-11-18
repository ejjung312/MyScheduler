using Domain.Models;

namespace Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        public Task<Account> Login(string userId, string password);
    }
}
