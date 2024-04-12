using iTunesSearch.Library.Models;
using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    
    public class CollectedViewModel : ViewModelBase
    {
        public ObservableCollection<CollectedMusicItemViewModel> SearchResults { get; } = new();

        private CollectedMusicItemViewModel? _selectedItem;
        public CollectedMusicItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }

        private long _userId;
        public CollectedViewModel(long userId)
        {
            _userId = userId;
            DoSearch();
        }
        
        private async void DoSearch()
        {
            SearchResults.Clear();
            var musics = await Music.SearchUserCollectedMusicAsync(_userId);

            foreach (var item in musics)
            {
                var vm = new CollectedMusicItemViewModel(item);
                SearchResults.Add(vm);
            }
            LoadCovers();
        }
        private async void LoadCovers()
        {
            foreach (var item in SearchResults.ToList())
            {
                await item.LoadCover();

            }
        }
    }

}
