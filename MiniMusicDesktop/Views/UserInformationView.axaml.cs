using Avalonia.Controls;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace MiniMusicDesktop.Views
{
    public partial class UserInformationView : ReactiveUserControl<UserInformationViewModel>
    {
        public UserInformationView()
        {
            //DataContext=;
            InitializeComponent();
            this.WhenActivated(action =>
             action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }



        private async Task DoShowDialogAsync(InteractionContext<MessageSuccessViewModel,
                                            AlbumViewModel?> interaction)
        {
            var dialog = new MessageSuccessViewModel();
            //await dialog.ShowDialog<AlbumViewModel?>(this.Parent as Window);
            
        }
    }
}
