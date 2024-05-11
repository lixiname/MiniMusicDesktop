using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
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

        private MusicItemViewModel _musicItem;
        public MusicItemViewModel MusicItem
        {
            get => _musicItem;
            set => this.RaiseAndSetIfChanged(ref _musicItem, value);
        }


        public CenterContainViewModel(InfoProfile userInfo)
        {
            _userInfo= userInfo;
            //_contentViewModel = new MarketViewModel();
            _contentViewModel = new RemarkViewModel();



        }
        public void ChangeToCollectedViewModel()
        {
            ContentViewModel= new CollectedViewModel(UserInfo.Id);
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
                  var rmarkViewModel = new RemarkViewModel();
                  MusicItem = newItem;
                  ContentViewModel = rmarkViewModel;
              });
        }

        public void ChangeToUserInformationSettingsViewModel(InfoProfile infoProfile)
        {
            ContentViewModel = new UserInformationViewModel(infoProfile);
        }
        

        public void ChangeToSettingsViewModel()
        {
            var settingsViewModel = new SettingsViewModel();
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
