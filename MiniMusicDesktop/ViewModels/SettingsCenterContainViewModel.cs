using MiniMusicDesktop.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public SettingsCenterContainViewModel()
        {
            _contentViewModel = new LanguageViewModel();

        }

        public void ChangeToLanguageViewModel()
        {
            ContentViewModel = new LanguageViewModel();
        }
        public void ChangeToRemarkViewModel()
        {
            ContentViewModel = new RemarkViewModel();
        }
        public void ChangeToTroubleTipsViewModel()
        {
            ContentViewModel = new TroubleTipsViewModel();
        }
        public void ChangeToAboutInformationViewModel()
        {
            ContentViewModel = new AboutInformationViewModel();
        }


       
    }
}
