using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class MUserViewModel : ViewModelBase
    {
        private string? _searchText;
        private bool _isBusy;
        public string? SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }
        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }

        private UserItemViewModel? _selectedItem;

        public ObservableCollection<UserItemViewModel> SearchResults { get; } = new();

        public UserItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }
        public MUserViewModel()
        {
            ChangeUserStateCommand = ReactiveCommand.Create(() =>
            {
                return SelectedItem;
            });

            this.WhenAnyValue(x => x.SearchText)
                 .Throttle(TimeSpan.FromMilliseconds(400))
                 .ObserveOn(RxApp.MainThreadScheduler)
                 .Subscribe(DoSearch!);

        }
        private async void DoSearch(string s)
        {
            IsBusy = true;
            SearchResults.Clear();
            
            if (!string.IsNullOrWhiteSpace(s))
            {
                var users = await User.UserListAsync();

                foreach (var item in users)
                {
                    var vm = new UserItemViewModel(item);
                    SearchResults.Add(vm);
                }   
                //LoadCovers();
                

            }
            IsBusy = false;


        }
        private async void LoadCovers()
        {
            foreach (var item in SearchResults.ToList())
            {
                await item.LoadCover();

            }
        }
        
        public ReactiveCommand<Unit, UserItemViewModel?> ChangeUserStateCommand { get; }
    }
}
