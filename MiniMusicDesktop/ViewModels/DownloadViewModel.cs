using Avalonia.Platform.Storage;
using LibVLCSharp.Shared;
using MiniMusicDesktop.Models;
using MiniMusicDesktop.Models.Config;
using MiniMusicDesktop.Models.DTO;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniMusicDesktop.ViewModels;

public class DownloadViewModel : ViewModelBase
{
    

    public ObservableCollection<DownLoadMusicItemViewModel> SearchResults { get; } = new();


    private DownLoadMusicItemViewModel? _selectedItem;
    public DownLoadMusicItemViewModel? SelectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
    }
    public ICommand OpenFolderCommand { get; }
    public DownloadViewModel()
    {
        OpenFolderCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            
            string baseurl = Directory.GetCurrentDirectory();
            var dir = Path.Combine(baseurl, @"LocalCache\musicDownload");
            Directory.CreateDirectory(dir);
            //var files = await storage.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
            //{
            //    Title = title,
            //    FileTypeFilter = new[] { ImageAll, FilePickerFileTypes.TextPlain }
            //});
        });

        ReadLocalDownload();
        
    }
   
    private async void ReadLocalDownload()
    {

        var directoryPath = Music.ReadDownloadConfig();
        // 检查目录是否存在
        if (Directory.Exists(directoryPath))
        {
            // 获取目录中的所有文件
            string[] files = Directory.GetFiles(directoryPath);

            // 遍历文件列表并输出文件名
            foreach (string file in files)
            {
                var fileName=Path.GetFileName(file);
                FileInfo fileInfo = new FileInfo(file);
                long fileSizeInBytes = fileInfo.Length;
                string size = (((double)fileSizeInBytes) / 1024 / 1024).ToString();
                var vm = new DownLoadMusicItemViewModel(fileName, size);
                SearchResults.Add(vm);
            }
           
        }
        else
        {
            Debug.WriteLine("指定的目录不存在。");
        }

    }
    
}
