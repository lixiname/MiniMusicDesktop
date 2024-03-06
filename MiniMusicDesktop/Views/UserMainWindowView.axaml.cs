using Avalonia.Controls;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.ViewModels;
using ReactiveUI;

using System.Threading.Tasks;

namespace MiniMusicDesktop.Views;

public partial class UserMainWindowView : ReactiveUserControl<UserMainWindowViewModel>
{
    public UserMainWindowView()
    {
        //DataContext=;
        InitializeComponent();
        this.WhenActivated(action =>
         action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    

    private async Task DoShowDialogAsync(InteractionContext<SearchMusicViewModel,
                                        AlbumViewModel?> interaction)
    {
        var dialog = new SearchMusicWindow();
        dialog.DataContext = interaction.Input;
        

        var result = await dialog.ShowDialog<AlbumViewModel?>(this.Parent as Window);
        interaction.SetOutput(result);
    }
}
