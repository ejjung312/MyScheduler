using ForSuccess.Commands;
using ForSuccess.State.Authenticators;
using ForSuccess.State.Navigators;
using System.Windows.Input;

namespace ForSuccess.ViewModels
{
    public class RegisterViewModel : ViewModelBase
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
			}
		}

		private string _userName;
		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
				OnPropertyChanged(nameof(UserName));
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
            }
		}

		private string _confirmPassword;
		public string ConfirmPassword
		{
			get
			{
				return _confirmPassword;
			}
			set
			{
				_confirmPassword = value;
				OnPropertyChanged(nameof(ConfirmPassword));
			}
		}

		public ICommand RegisterCommand { get; }
		public ICommand ViewLoginCommand { get; }

        public RegisterViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator, IRenavigator loginRenavigator)
        {
			RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator);
			ViewLoginCommand = new RenavigateCommand(loginRenavigator);
        }
    }
}
