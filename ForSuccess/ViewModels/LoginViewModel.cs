using ForSuccess.Commands;
using ForSuccess.State.Navigators;
using System.Windows.Input;

namespace ForSuccess.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel(IRenavigator loginRenavigator)
        {
            LoginCommand = new LoginCommand(this, loginRenavigator);
        }
    }
}
