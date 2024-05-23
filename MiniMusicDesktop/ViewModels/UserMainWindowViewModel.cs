using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Extensions.Media;
using MiniMusicDesktop.Models;
using MiniMusicDesktop.Models.Common.Enum;
using MiniMusicDesktop.Models.DTO;
using ReactiveUI;
using SkiaSharp;
namespace MiniMusicDesktop.ViewModels
{
    public class UserMainWindowViewModel : ViewModelBase
    {
        public ICommand BuyMusicCommand { get; }
        public ICommand MarktetCommand { get; }
        public ICommand DownloadCommand { get; }
        public ICommand CollectedCommand { get; }
        public ICommand SettingsCommand { get; }
        public ICommand TalkHistoryCommand { get; }
        public ICommand StyleCommand { get; }
        public ICommand AgreedMusicCommand { get; }
        public ICommand CollectMusicCommand { get; }
        public ICommand DownloadMusicCommand { get; }
        
        
        public ReactiveCommand<Unit, Unit> UserInformationSettingsCommand { get; }



        public Interaction<SearchMusicViewModel, AlbumViewModel?> ShowDialog { get; }

        private CenterContainViewModel _centerContainViewModel;

        public CenterContainViewModel CenterContainViewModel
        {
            get=>_centerContainViewModel;
            set =>this.RaiseAndSetIfChanged(ref _centerContainViewModel, value);
        }

        private InfoProfile _userInfo;
        public InfoProfile UserInfo
        {
            get => _userInfo;
            set => this.RaiseAndSetIfChanged(ref _userInfo, value);
        }

        private string _currentMusicName;
        public string CurrentMusicName
        {
            get => _currentMusicName;
            set => this.RaiseAndSetIfChanged(ref _currentMusicName, value);
        }
        private string _startTime;
        public string StartTime
        {
            get => _startTime;
            set => this.RaiseAndSetIfChanged(ref _startTime, value);
        }

        private string _endTime;
        public string EndTime
        {
            get => _endTime;
            set => this.RaiseAndSetIfChanged(ref _endTime, value);
        }

        private MusicStatusEnum _musicStatus= MusicStatusEnum.Start;
        public MusicStatusEnum MusicStatus
        {
            get => _musicStatus;
            set => this.RaiseAndSetIfChanged(ref _musicStatus, value);
        }

        public void MusicChangePlayStatus()
        {
            if (MusicStatus == MusicStatusEnum.Start)
            {
                MusicStatus = MusicStatusEnum.Init;
            }
            else if (MusicStatus == MusicStatusEnum.Init)
            {
                MusicStatus = MusicStatusEnum.Restart;
            }
            else if (MusicStatus == MusicStatusEnum.Pause)
            {
                MusicStatus = MusicStatusEnum.Restart;
            }
            else if (MusicStatus == MusicStatusEnum.Restart)
            {
                MusicStatus = MusicStatusEnum.Pause;
            }
        }
        public async Task<string> CacheMusic()
        {
            
            var musicItem = CenterContainViewModel.MusicItem;
            if(musicItem == null)
            {
                Console.WriteLine();
                throw new ArgumentNullException(nameof(musicItem));
            }
            var _item = new Music
            {
                Id = musicItem.Id,
            };
            CurrentMusicName=musicItem.Name;

            var musicContent=await _item.LoadMediaBitmapAsync();
            string baseurl = Directory.GetCurrentDirectory();
            var dir = Path.Combine(baseurl, @"LocalCache\musicContent");
            Directory.CreateDirectory(dir);
            var filePath = Path.Combine(dir, "(Live).mp3");

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                //await fileStream.WriteAsync(musicContent, 0, musicContent.Length);
                await musicContent.CopyToAsync(fileStream);
            }
            return filePath;

        }

        

        public bool BackState { get; set; } = true;

        public UserMainWindowViewModel(InfoProfile userInfo) 
        {
            
            _currentMusicName = "";
            _startTime = "00:00";
            _endTime = "04:00";
            _userInfo = userInfo;
           _centerContainViewModel = new CenterContainViewModel(_userInfo);

            StyleCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                
            });

            MarktetCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToMarketViewModel();
            });

            DownloadCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToDownloadViewModel();
            });

            CollectedCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToCollectedViewModel();
            });

            ShowDialog = new Interaction<SearchMusicViewModel, AlbumViewModel?>();

            SettingsCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToSettingsViewModel();
            });

            UserInformationSettingsCommand=ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToUserInformationSettingsViewModel(UserInfo);
            });
            TalkHistoryCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToTalkHistoryViewModel();
            });
            


            AgreedMusicCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var userCache=User.ReadLocalCache();
                var musicItem = CenterContainViewModel.MusicItem;
                await Music.AgreedMusicAsync(userCache.Id, musicItem.Id, DateTime.Now);
            });
            CollectMusicCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var userCache = User.ReadLocalCache();
                var musicItem = CenterContainViewModel.MusicItem;
                await Music.CollectMusicAsync(userCache.Id, musicItem.Id, DateTime.Now);
            });
            DownloadMusicCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var userCache = User.ReadLocalCache();
                var musicItem = CenterContainViewModel.MusicItem;
                var musicContent = await Music.DownLoadMusicAsync(userCache.Id, musicItem.Id, DateTime.Now);
                var directoryPath = Music.ReadDownloadConfig();
                
                var filePath = Path.Combine(directoryPath, $"{musicItem.Name}.mp3");
                
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                {
                    await musicContent.CopyToAsync(fileStream);
                }
            });

        BuyMusicCommand =ReactiveCommand.CreateFromTask(async () =>
            {

                var store = new SearchMusicViewModel();
                
                var result = await ShowDialog.Handle(store);
                
                if (result != null)
                {
                    Albums.Add(result);
                }
            });
            

        }

        

        public ObservableCollection<AlbumViewModel> Albums { get; } = new();
    }
}
