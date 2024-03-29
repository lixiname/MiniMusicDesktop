﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using MiniMusicDesktop.Models;
using ReactiveUI;
namespace MiniMusicDesktop.ViewModels
{
    public class UserMainWindowViewModel : ViewModelBase
    {
        public ICommand BuyMusicCommand { get; }
        public ICommand MarktetCommand { get; }
        public ICommand DownloadCommand { get; }
        public ICommand CollectedCommand { get; }
        public Interaction<SearchMusicViewModel, AlbumViewModel?> ShowDialog { get; }

        private CenterContainViewModel _centerContainViewModel;

        public CenterContainViewModel CenterContainViewModel
        {
            get=>_centerContainViewModel;
            set =>this.RaiseAndSetIfChanged(ref _centerContainViewModel, value);
        }

        private User _userInfo;
        public User UserInfo
        {
            get => _userInfo;
            set => this.RaiseAndSetIfChanged(ref _userInfo, value);
        }

        public UserMainWindowViewModel(User userInfo) 
        {
            _userInfo = userInfo;
           _centerContainViewModel = new CenterContainViewModel();
            
            MarktetCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToMarketViewModel();
            });

            DownloadCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToDownloadViewModel();
            });

            CollectedCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                CenterContainViewModel.ChangeToCollectedViewModel();
            });

            ShowDialog = new Interaction<SearchMusicViewModel, AlbumViewModel?>();

            

            BuyMusicCommand =ReactiveCommand.CreateFromTask(async () =>
            {
                
                var store = new SearchMusicViewModel();
                
                var result = await ShowDialog.Handle(store);
                
                if (result != null)
                {
                    Albums.Add(result);
                }
            });
        }

        public ObservableCollection<AlbumViewModel> Albums { get; } = new();
    }
}
