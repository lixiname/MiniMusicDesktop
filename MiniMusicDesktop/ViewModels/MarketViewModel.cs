using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class MarketViewModel : ViewModelBase
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

        public ObservableCollection<MusicItemViewModel> SearchResults { get; } = new();


        private MusicItemViewModel? _selectedItem;
        public MusicItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }

        public MarketViewModel()
        {
            
            this.WhenAnyValue(x => x.SearchText)
                 .Throttle(TimeSpan.FromMilliseconds(400))
                 .ObserveOn(RxApp.MainThreadScheduler)
                 .Subscribe(DoSearch!);
            //InitSearch();

        }
        
        private async void InitSearch()
        {
            //SearchResults.Clear();
            var musics = await Music.SearchReviewAsync();
            foreach (var item in musics)
            {
                var vm = new MusicItemViewModel(item);
                SearchResults.Add(vm);
            }
            //LoadCovers();

        }
        private async void DoSearch(string s)
        {
            IsBusy = true;
            SearchResults.Clear();

            if (!string.IsNullOrWhiteSpace(s))
            {
                var musics = await Music.SearchReviewAsync();

                foreach (var item in musics)
                {
                    var vm = new MusicItemViewModel(item);
                    SearchResults.Add(vm);
                }
                LoadCovers();

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
    }
}
