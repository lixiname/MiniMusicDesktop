using Avalonia.Controls;
using Avalonia.Extensions.Media;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.Models.Common.Enum;
using MiniMusicDesktop.ViewModels;
using ReactiveUI;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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
    private string MusicMediaPath;


    private async void Change_style(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var panel = this.FindControl<Panel>("FatherRoot");
        if (ViewModel!.BackState == true)
        {
            panel.Background = new SolidColorBrush(Colors.AliceBlue, 0.5);
        }
        else
        {
            ViewModel!.BackState = false;
            panel.Background = new SolidColorBrush(Colors.Black, 0.5);
        }
        
        
        
        

    }

    private async void Button_init_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var musicPath = await ViewModel!.CacheMusic();
        MusicMediaPath = musicPath;
        Console.WriteLine(musicPath);
        
    }
    private async void Init()
    {
        var musicPath = await ViewModel!.CacheMusic();
        MusicMediaPath = musicPath;
        Console.WriteLine(musicPath);
        PlayerView videoView = this.FindControl<PlayerView>("playerView");
        videoView.Play(MusicMediaPath);

    }

    private PlayerView videoView;

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        //videoView.Play(files[0].Path);
        //files.Count;
        ViewModel!.MusicChangePlayStatus();
        if (ViewModel!.MusicStatus == MusicStatusEnum.Init)
        {
            Init();

        }
        else if (ViewModel!.MusicStatus==MusicStatusEnum.Pause)
        {
            PlayerView videoView = this.FindControl<PlayerView>("playerView");
            videoView.Play(MusicMediaPath);
            
        }
        else if(ViewModel!.MusicStatus == MusicStatusEnum.Restart)
        {
            PlayerView videoView = this.FindControl<PlayerView>("playerView");
            videoView.Pause();
        }
        
        
        
    }
    private void f(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        var files = topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false
        }).Result;
        // 启动异步操作以打开对话框。

        //var files = await storage.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        //{
        //    Title = title,
        //    可以添加自定义文件类型，也可以从内置文件类型添加。请参阅“定义自定义文件类型”，了解如何创建自定义文件类型。
        //    FileTypeFilter = new[] { ImageAll, FilePickerFileTypes.TextPlain }
        //});
    }

    private async Task DoShowDialogAsync(InteractionContext<SearchMusicViewModel,
                                        AlbumViewModel?> interaction)
    {
        var dialog = new SearchMusicWindow();
        dialog.DataContext = interaction.Input;
        
        var result = await dialog.ShowDialog<AlbumViewModel?>(this.Parent as Window);
        interaction.SetOutput(result);
    }
    private void _playMusic()
    {
        PlayerView VideoView = this.FindControl<PlayerView>("playerView");
        string baseurl = Directory.GetCurrentDirectory();
        var path = System.IO.Path.Combine(baseurl, @"Assets\(Live).mp3");
        VideoView.Play(path);
    }
}
