using Domain.Models;

namespace Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        UserAlreadyExists,
        PasswordDoNotMatch,
    }

    public interface IAuthenticationService
    {
        public Task<Account> Login(string userId, string password);

        public Task<RegistrationResult> Register(string userId, string userName, string password, string confirmPassword);
    }
}
