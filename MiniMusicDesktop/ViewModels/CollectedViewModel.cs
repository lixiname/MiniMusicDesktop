using iTunesSearch.Library.Models;
using MiniMusicDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class CollectedViewModel : ViewModelBase
    {
        public ObservableCollection<MusicViewModel> SearchResults { get; } = new();

        public CollectedViewModel()
        {
            DoSearch();
        }
        private async void DoSearch()
        {
            SearchResults.Clear();
            var results=await Music.SearchAsync();
            if (results != null)
            {
                foreach (var music in results)
                {
                    var vm = new MusicViewModel(music);
                    SearchResults.Add(vm);
                }
                LoadCovers();
                
            }

        }
        private async void LoadCovers()
        {
            foreach (var album in SearchResults.ToList())
            {
                await album.LoadCover();

            }
        }

    }
}
