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
   
    public class MCenterContainViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }
        public MCenterContainViewModel()
        {
            _contentViewModel = new MarketViewModel();

        }
        public void ChangeToMarketManagementViewModel()
        {
            ContentViewModel = new MMarketViewModel();
        }
        public void ChangeToRemarkManagementViewModel()
        {
            ContentViewModel = new MRemarkViewModel();
        }
        public void ChangeToUserManagementViewModel()
        {
            ContentViewModel = new MUserViewModel();
        }












    }
}
