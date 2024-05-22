using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace MiniMusicDesktop.Views
{
    public partial class FindPwdView : UserControl
    {
        private WindowNotificationManager? _manager;
        public FindPwdView()
        {
            InitializeComponent();
        }
        private void Button_Click_ChangePasswordChar(object sender, RoutedEventArgs e)
        {
            if (PasswordInput.PasswordChar == '*')
            {
                PasswordInput.PasswordChar = new char();
            }
            else
            {
                PasswordInput.PasswordChar = '*';
            }
        }
        private void Button_Click_ChangeRepeatPasswordChar(object sender, RoutedEventArgs e)
        {
            if (RepeatPasswordInput.PasswordChar == '*')
            {
                RepeatPasswordInput.PasswordChar = new char();
            }
            else
            {
                RepeatPasswordInput.PasswordChar = '*';
            }
        }
    }
}
