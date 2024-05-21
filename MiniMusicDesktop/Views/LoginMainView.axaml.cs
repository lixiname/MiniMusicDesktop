using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MiniMusicDesktop.Views
{
    public partial class LoginMainView : UserControl
    {
        public LoginMainView()
        {
            InitializeComponent();
            
        }
        private void Button_Click_ChangePasswordChar(object sender, RoutedEventArgs e)
        {
            if (PasswordInput.PasswordChar=='*')
            {
                PasswordInput.PasswordChar= new char();
            }
            else
            {
                PasswordInput.PasswordChar = '*';
            }
            
        }

    }
}
