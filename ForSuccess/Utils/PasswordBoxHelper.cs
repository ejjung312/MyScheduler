using System.Windows;
using System.Windows.Controls;

namespace ForSuccess.Utils
{
    public static class PasswordBoxHelper
    {
        /**
         * Attached Property: PasswordBox와 같은 컨트롤에 추가적인 기능을 제공
         * BoundPassword: ViewModel에 바인딩하기 위한 Attached Property로 사용
         */
        public static readonly DependencyProperty BoundPasswordProperty = DependencyProperty.RegisterAttached("BoundPassword", typeof(string), 
            typeof(PasswordBoxHelper), new PropertyMetadata("<Default>", OnBoundPasswordChanged));

        public static readonly DependencyProperty BoundConfirmPasswordProperty = DependencyProperty.RegisterAttached("BoundConfirmPassword", typeof(string),
            typeof(PasswordBoxHelper), new PropertyMetadata("<Default>", OnBoundConfirmPasswordChanged));

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            SetBoundPassword(passwordBox, passwordBox.Password);
        }

        private static void ConfirmPasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            SetBoundConfirmPassword(passwordBox, passwordBox.Password);
        }

        public static string GetBoundPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(BoundPasswordProperty);
        }

        public static void SetBoundPassword(DependencyObject obj, string value)
        {
            obj.SetValue(BoundPasswordProperty, value);
        }

        public static string GetBoundConfirmPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(BoundConfirmPasswordProperty);
        }

        public static void SetBoundConfirmPassword(DependencyObject obj, string value)
        {
            obj.SetValue(BoundConfirmPasswordProperty, value);
        }

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            if (passwordBox == null) return;

            passwordBox.PasswordChanged -= PasswordChanged;
            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static void OnBoundConfirmPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            if (passwordBox == null) return;

            passwordBox.PasswordChanged -= ConfirmPasswordChanged;
            passwordBox.PasswordChanged += ConfirmPasswordChanged;
        }
    }
}
