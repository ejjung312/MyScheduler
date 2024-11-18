using Domain.Exceptions;
using ForSuccess.State.Authenticators;
using ForSuccess.State.Navigators;
using ForSuccess.ViewModels;

namespace ForSuccess.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        private void LoginViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _loginViewModel.CanLogin && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            string userId = _loginViewModel.UserId;
            string password = _loginViewModel.Password;

            try
            {
                await _authenticator.Login(userId, password);
                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {
                string errorMessage = "User does not exists.";
            }
        }
    }
}
