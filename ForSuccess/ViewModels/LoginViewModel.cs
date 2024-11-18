using ForSuccess.Commands;
using ForSuccess.State.Authenticators;
using ForSuccess.State.Navigators;
using System.Windows.Input;

namespace ForSuccess.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
		private string _userId;
		public string UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
				OnPropertyChanged(nameof(UserId));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		public bool CanLogin => !string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(Password);

		public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator)
        {
            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
        }
    }
}
