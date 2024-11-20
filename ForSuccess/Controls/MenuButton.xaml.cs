using FontAwesome6;
using System.Windows;
using System.Windows.Controls;

namespace ForSuccess.Controls
{
    /// <summary>
    /// MenuButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(MenuButton));


        public EFontAwesomeIcon Icon
        {
            get { return (EFontAwesomeIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(EFontAwesomeIcon), typeof(MenuButton));
    }
}
