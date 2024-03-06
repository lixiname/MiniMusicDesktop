
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMusicDesktop.Models;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace MiniMusicDesktop.ViewModels
{
    public class AlbumViewModel : ViewModelBase
    {
        private readonly Album _album;
        public AlbumViewModel(Album album)
        {
            _album = album;
        }

        public string Artist => _album.Artist;

        public string Title
        {
            get
            {
                return _album.Title;
            }
        }

        private Bitmap? _cover;

        public Bitmap? Cover
        {
            get => _cover;
            private set => this.RaiseAndSetIfChanged(ref _cover, value);
        }

        public async Task LoadCover()
        {
            await using (var imageStream = await _album.LoadCoverBitmapAsync())
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
            }
        }
    }
}
