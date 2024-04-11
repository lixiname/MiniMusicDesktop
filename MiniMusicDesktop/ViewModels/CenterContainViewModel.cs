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
        public CenterContainViewModel()
        {
            _contentViewModel = new CollectedViewModel();
            
        }
        public void ChangeToCollectedViewModel()
        {
            ContentViewModel= new CollectedViewModel();
        }
        public void ChangeToDownloadViewModel()
        {
            ContentViewModel = new DownloadViewModel();
        }

        public void ChangeToMarketViewModel()
        {
            ContentViewModel = new MarketViewModel();
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
