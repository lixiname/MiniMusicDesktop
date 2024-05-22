using MiniMusicDesktop.Models;
using MiniMusicDesktop.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class SettingsCenterContainViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        private InfoProfile _infoProfile;
        public InfoProfile InfoProfile
        {
            get => _infoProfile;
            set => this.RaiseAndSetIfChanged(ref _infoProfile, value);
        }

        public SettingsCenterContainViewModel(InfoProfile infoProfile)
        {
            _infoProfile = infoProfile;
            _contentViewModel = new LanguageViewModel();
            

        }

        public void ChangeToLanguageViewModel()
        {
            ContentViewModel = new LanguageViewModel();
        }
        public void ChangeToRemarkViewModel()
        {
            ContentViewModel = new CustomerViewModel();
        }

        public void ChangeToTroubleTipsViewModel()
        {
            ContentViewModel = new TroubleTipsViewModel();
        }
        public void ChangeToAboutInformationViewModel()
        {
            ContentViewModel = new AboutInformationViewModel();
        }
        public void ChangeToFindPassowrdViewModel()
        {
            var _findPwdViewModel = new FindPwdViewModel(InfoProfile);
            _findPwdViewModel.ResetPwdCommand
                .Take(1)
                .Subscribe(newItem =>
                {
                    ContentViewModel = new LanguageViewModel();
                });

            ContentViewModel = _findPwdViewModel;
        }



    }
}
