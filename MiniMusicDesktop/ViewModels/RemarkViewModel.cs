using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.Common.Enum;
using System.Windows.Input;
using System.Diagnostics;
using MiniMusicDesktop.Models.DTO;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace MiniMusicDesktop.ViewModels
{
    public class RemarkViewModel : ViewModelBase
    {
        private Music? _music;
        public Music? Music
        {
            get => _music;
            set => this.RaiseAndSetIfChanged(ref _music, value);
        }
        private Bitmap? _cover;

        public Bitmap? Cover
        {
            get => _cover;
            private set => this.RaiseAndSetIfChanged(ref _cover, value);
        }

        public string Name => _music.Name;

        public string Author => _music.Author;

        public string MusicType
        {
            get
            {
                switch (_music.MusicType)
                {
                    case MusicTypeEnum.Type0: return MusicTypeConst.Type0;
                    case MusicTypeEnum.Type1: return MusicTypeConst.Type1;
                    case MusicTypeEnum.Type2: return MusicTypeConst.Type2;
                    case MusicTypeEnum.Type3: return MusicTypeConst.Type3;
                    default: return MusicTypeConst.Type0;
                }


            }
        }

        private string _remarkContent=string.Empty;

        public string RemarkContent
        {
            get => _remarkContent;
            private set => this.RaiseAndSetIfChanged(ref _remarkContent, value);
        }
        
        public ICommand RemarkCommand { get; }


        private RemarkItemViewModel? _selectedItem;

        public ObservableCollection<RemarkItemViewModel> SearchResults { get; } = new();

        public RemarkItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }
        public RemarkViewModel(Music music)
        {
            RemarkCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                

                var UserCacheInfo=User.ReadLocalCache();
                var talk = new TalkMusicDTO
                {
                    MusicId=Music.Id,
                    UploadUserId=Music.UploadUserId,
                    TalkId=UserCacheInfo.Id,
                    Contents= RemarkContent,
                    time=DateTime.Now,
                    AgreedNum=0,
                };
                await Music.TalkMusicAsync(talk);
                Debug.WriteLine("");
                DoSearch();
                RemarkContent = string.Empty;
                
            });

            _music = music;
            ChangeUserStateCommand = ReactiveCommand.Create(() =>
            {
                return SelectedItem;
            });
            LoadMusicContent();
            DoSearch();

        }

        

        private async void LoadMusicContent()
        {

            SearchResults.Clear();
            var users = await Music.MusicContentAsync();
            await using (var imageStream = await Music.LoadCoverBitmapAsync())
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
            }
        }

        private async void DoSearch()
        {
            
            SearchResults.Clear();

            var talks = await Music.SearchSingleMusicTalkAsync(Music.Id);

            foreach (var item in talks)
            {
                var vm = new RemarkItemViewModel(item);
                SearchResults.Add(vm);
            }
            //LoadCovers();
        }
        private async void LoadCovers()
        {
            foreach (var item in SearchResults.ToList())
            {
                await item.LoadCover();

            }
        }

        public ReactiveCommand<Unit, RemarkItemViewModel?> ChangeUserStateCommand { get; }
    }
}
