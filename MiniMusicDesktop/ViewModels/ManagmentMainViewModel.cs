using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniMusicDesktop.ViewModels
{
    public class ManagmentMainViewModel : ViewModelBase
    {
        private InfoProfile _userInfo;
        public InfoProfile UserInfo
        {
            get => _userInfo;
            set => this.RaiseAndSetIfChanged(ref _userInfo, value);
        }

        

        private MCenterContainViewModel _centerContainViewModel;

        public MCenterContainViewModel CenterContainViewModel
        {
            get => _centerContainViewModel;
            set => this.RaiseAndSetIfChanged(ref _centerContainViewModel, value);
        }

       

        public ICommand MarktetManagementCommand { get; }
        public ICommand RemarkManagementCommand { get; }
        public ICommand UserManagementCommand { get; }

        public ICommand MusicCollectChartCommand { get; }
        public ICommand MusicAgreedChartCommand { get; }
        public ICommand MusicDownloadChartCommand { get; }
               
        public ManagmentMainViewModel(InfoProfile userInfo)
        {
            _userInfo = userInfo;
            _centerContainViewModel = new MCenterContainViewModel();

            MarktetManagementCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToMarketManagementViewModel();
            });
            RemarkManagementCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToRemarkManagementViewModel();
            });
            UserManagementCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToUserManagementViewModel();
            });

            MusicCollectChartCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToMusicCollectChart();
            });
            MusicAgreedChartCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToMusicAgreedChart();
            });
            MusicDownloadChartCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToMusicDownloadChart();
            });
        }
    }
}
