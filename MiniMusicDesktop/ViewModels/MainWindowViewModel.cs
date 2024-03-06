using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMusicDesktop.Models;
namespace MiniMusicDesktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        
        public MainWindowViewModel()
        {
            var loginMainViewModel=new LoginMainViewModel();
            //_contentViewModel = new LoginMainViewModel();
            Observable.Merge(
                loginMainViewModel.LoginCommand,
                loginMainViewModel.QuitCommand.Select(_ => (User?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        if (newItem.LoginSuccess==1)
                        {
                            if (newItem.InfoTypes == 0)
                            {
                                ContentViewModel = new UserMainWindowViewModel(newItem);
                            }
                            else if (newItem.InfoTypes == 1)
                            {
                                ContentViewModel = new ManagmentMainViewModel();
                            }
                        }
                        else
                        {

                            throw new Exception("login error");
                        }
                        
                        
                    }
                    
                });

            ContentViewModel = loginMainViewModel;


        }
    }
}
