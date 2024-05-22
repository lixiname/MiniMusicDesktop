using Avalonia;
using MiniMusicDesktop.Models;
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

        
        //应用设置
        public ICommand SettingsCommand { get; }
        //意见反馈
        public ICommand RemarkCommand { get; }
        //常见问题
        public ICommand TroubleTipsCommand { get; }
        //关于软件
        public ICommand AboutInformationCommand { get; }
        //密码找回
        public ICommand FindPassowrdCommand { get; }


        private InfoProfile _infoProfile;
        public InfoProfile InfoProfile
        {
            get => _infoProfile;
            set => this.RaiseAndSetIfChanged(ref _infoProfile, value);
        }


        public SettingsViewModel(InfoProfile infoProfile)
        {
            _infoProfile = infoProfile;
            _centerContainViewModel = new SettingsCenterContainViewModel(InfoProfile);
            CloseSettingsCommand = ReactiveCommand.Create(() => { }) ;
            ChangeProfileCommand = ReactiveCommand.Create(() => { });

            
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
            FindPassowrdCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToFindPassowrdViewModel();
            });

            



        }
        public string Description
        {
            get=> _description; 
            set=>this.RaiseAndSetIfChanged(ref _description,value); 
        }

        


    }
}
