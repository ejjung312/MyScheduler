using Domain.Services.AuthenticationServices;

namespace ForSuccess.State.Authenticators
{
    public interface IAuthenticator
    {
        // 이벤트가 발생했을 때 구독자들에게 알림
        event Action StateChanged;

        bool IsLoggedIn { get; }

        Task<RegistrationResult> Register(string userId, string userName, string password, string confirmPassword);
        Task Login(string userId, string password);
        void Logout();
    }
}
