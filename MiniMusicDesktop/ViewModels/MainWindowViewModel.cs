using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMusicDesktop.Models;
using MiniMusicDesktop.Models.Common;
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

        private LoginMainViewModel _loginMainViewModel;
        public MainWindowViewModel()
        {
            _loginMainViewModel = new LoginMainViewModel();
            //_contentViewModel = new LoginMainViewModel();
            Observable.Merge(
                _loginMainViewModel.LoginCommand,
                _loginMainViewModel.QuitCommand.Select(_ => (InfoProfile?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        if (newItem.LoginSuccess==LoginStateEnum.Login)
                        {
                            if (newItem.InfoTypes == InfoTypeEnum.User)
                            {
                                
                                var userMainWindowViewModel = new UserMainWindowViewModel(newItem);
                                ContentViewModel = userMainWindowViewModel;
                            }
                            else if (newItem.InfoTypes == InfoTypeEnum.ManagmentUser)
                            {
                                ContentViewModel = new ManagmentMainViewModel(newItem);
                            }
                            else if (newItem.InfoTypes == InfoTypeEnum.NullUser)
                            {
                                throw new Exception("login error");
                            }
                        }
                        else
                        {

                            throw new Exception("login error");
                        }
                        
                        
                    }
                    
                });
            _loginMainViewModel.RegisterCommand
               .Take(1)
               .Subscribe(newItem =>
               {
                   var registerMainViewModel = new RegisterMainViewModel();
                   Observable.Merge(registerMainViewModel.RegisterCommand,
                       registerMainViewModel.QuitCommand.Select(_ => (User?)null))
                   .Take(1)
                   .Subscribe(newItem =>
                   {
                       if (newItem != null)
                       {

                           _loginMainViewModel.InitTable(newItem);
                           ContentViewModel = _loginMainViewModel;

                       }
                       else
                       {

                           ContentViewModel = _loginMainViewModel;
                       }
                   });

                   ContentViewModel = registerMainViewModel;
               });

            ContentViewModel = _loginMainViewModel;
         
        }
    }
}
