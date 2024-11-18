
using Domain.Services.AuthenticationServices;
using ForSuccess.State.Authenticators;
using ForSuccess.State.Navigators;
using ForSuccess.ViewModels;

namespace ForSuccess.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
               RegistrationResult registrationResult = await _authenticator.Register(
                    _registerViewModel.UserId,
                    _registerViewModel.UserName,
                    _registerViewModel.Password,
                    _registerViewModel.ConfirmPassword);
                
                switch(registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Renavigate();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
