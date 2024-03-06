using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
