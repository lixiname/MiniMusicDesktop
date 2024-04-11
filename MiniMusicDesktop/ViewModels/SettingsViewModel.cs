using Avalonia;

using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniMusicDesktop.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private string _description = string.Empty;
        public ReactiveCommand<Unit, Unit> CloseSettingsCommand { get; }
        public ReactiveCommand<Unit, Unit> ChangeProfileCommand { get; }



        private SettingsCenterContainViewModel _centerContainViewModel;

        public SettingsCenterContainViewModel CenterContainViewModel
        {
            get => _centerContainViewModel;
            set => this.RaiseAndSetIfChanged(ref _centerContainViewModel, value);
        }

        public ICommand PasswordRemarkCommand { get; }
        //应用设置
        public ICommand SettingsCommand { get; }
        //意见反馈
        public ICommand RemarkCommand { get; }
        //常见问题
        public ICommand TroubleTipsCommand { get; }
        //关于软件
        public ICommand AboutInformationCommand { get; }

      

        public SettingsViewModel()
        {
            _centerContainViewModel = new SettingsCenterContainViewModel();
            CloseSettingsCommand = ReactiveCommand.Create(() => { }) ;
            ChangeProfileCommand = ReactiveCommand.Create(() => { });

            PasswordRemarkCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToLanguageViewModel();
            });
            SettingsCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToLanguageViewModel();
            });
            RemarkCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToRemarkViewModel();
            });
            TroubleTipsCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToTroubleTipsViewModel();
            });
            AboutInformationCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToAboutInformationViewModel();
            });

            
        }
        public string Description
        {
            get=> _description; 
            set=>this.RaiseAndSetIfChanged(ref _description,value); 
        }

        


    }
}
