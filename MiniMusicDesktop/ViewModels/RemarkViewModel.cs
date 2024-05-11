using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class RemarkViewModel : ViewModelBase
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

        private RemarkItemViewModel? _selectedItem;

        public ObservableCollection<RemarkItemViewModel> SearchResults { get; } = new();

        public RemarkItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }
        public RemarkViewModel()
        {
            ChangeUserStateCommand = ReactiveCommand.Create(() =>
            {
                return SelectedItem;
            });

            DoSearch("");

        }
        private async void DoSearch(string s)
        {
            
            SearchResults.Clear();
            var users = await User.UserListAsync();

            foreach (var item in users)
            {
                var vm = new RemarkItemViewModel(item);
                SearchResults.Add(vm);
            }
            //LoadCovers();



        }
        private async void LoadCovers()
        {
            foreach (var item in SearchResults.ToList())
            {
                await item.LoadCover();

            }
        }

        public ReactiveCommand<Unit, RemarkItemViewModel?> ChangeUserStateCommand { get; }
    }
}
