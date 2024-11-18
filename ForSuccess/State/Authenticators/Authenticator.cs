using Domain.Models;
using Domain.Services.AuthenticationServices;
using ForSuccess.State.Accounts;

namespace ForSuccess.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }

        public Account CurrentAccount
        {
            get => _accountStore.CurrentAccount;
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task Login(string userId, string password)
        {
            CurrentAccount = await _authenticationService.Login(userId, password);
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string userId, string userName, string password, string confirmPassword)
        {
            return await _authenticationService.Register(userId, userName, password, confirmPassword);
        }
    }
}
