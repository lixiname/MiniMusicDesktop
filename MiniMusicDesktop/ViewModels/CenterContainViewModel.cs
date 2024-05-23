using MiniMusicDesktop.Models;
using ReactiveUI;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class CenterContainViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            set=> this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        private InfoProfile _userInfo;
        public InfoProfile UserInfo
        {
            get => _userInfo;
            set => this.RaiseAndSetIfChanged(ref _userInfo, value);
        }

        private Music _musicItem;
        public Music MusicItem
        {
            get => _musicItem;
            set => this.RaiseAndSetIfChanged(ref _musicItem, value);
        }


        public CenterContainViewModel(InfoProfile userInfo)
        {
            _userInfo= userInfo;
            _contentViewModel = new MarketViewModel();

            //_contentViewModel = new RemarkViewModel();
            //test
            //_contentViewModel = new BarChartViewModel();
            //_contentViewModel = new LineChartViewModel();
            User.WriteLocalCache(UserInfo);
            //_contentViewModel = new PieChartViewModel();
           
        }
        
        public void ChangeToCollectedViewModel()
        {
           var currentViewModel = new CollectedViewModel(UserInfo.Id);
            ContentViewModel = currentViewModel;
            currentViewModel.PlayMusicCommand
              .Take(1)
              .Subscribe(newItem =>
              {
                  var rmarkViewModel = new RemarkViewModel(newItem._item);
                  MusicItem = newItem._item;
                  ContentViewModel = rmarkViewModel;
              });
        }
        public void ChangeToDownloadViewModel()
        {
            ContentViewModel = new DownloadViewModel();
        }

        public void ChangeToMarketViewModel()
        {
            var currentViewModel = new MarketViewModel();
            ContentViewModel = currentViewModel;

            currentViewModel.PlayMusicCommand
              .Take(1)
              .Subscribe(newItem =>
              {
                  var rmarkViewModel = new RemarkViewModel(newItem._item);
                  MusicItem = newItem._item;
                  ContentViewModel = rmarkViewModel;
              });
        }

        public void ChangeToUserInformationSettingsViewModel(InfoProfile infoProfile)
        {
            ContentViewModel = new UserInformationViewModel(infoProfile);
        }
        public void ChangeToTalkHistoryViewModel()
        {
            ContentViewModel = new TalkHistoryViewModel();
        }

        


        public void ChangeToSettingsViewModel()
        {
            var settingsViewModel = new SettingsViewModel(UserInfo);
            Observable.Merge(
                              settingsViewModel.ChangeProfileCommand.Select(_ => (User?)null),
                              settingsViewModel.CloseSettingsCommand.Select(_ => (User?)null))
                              .Take(1)
                              .Subscribe(newItem =>
                              {
                                  ContentViewModel = new MarketViewModel();
                              });
            ContentViewModel = settingsViewModel;

        }
    }
}
