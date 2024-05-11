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
    public class DownloadViewModel : ViewModelBase
    {
        

        public ObservableCollection<DownLoadMusicItemViewModel> SearchResults { get; } = new();


        private DownLoadMusicItemViewModel? _selectedItem;
        public DownLoadMusicItemViewModel? SelectedItem
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
        }

        public DownloadViewModel()
        {
            DoSearch();
        }

        private async void DoSearch()
        {
            
            SearchResults.Clear();
            var musics = await Music.SearchReviewAsync("");

            foreach (var item in musics)
            {
                var vm = new DownLoadMusicItemViewModel(item);
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
