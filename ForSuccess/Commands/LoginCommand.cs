using ForSuccess.State.Navigators;
using ForSuccess.ViewModels;
using System.Windows.Input;

namespace ForSuccess.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _renavigator = renavigator;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _renavigator.Renavigate();
        }
    }
}
