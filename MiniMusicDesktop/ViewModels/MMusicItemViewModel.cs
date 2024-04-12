using Avalonia.Media.Imaging;
using MiniMusicDesktop.Models;
using MiniMusicDesktop.Models.Common.Enum;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class MMusicItemViewModel : ViewModelBase
    {
        private readonly Music _item;
        public MMusicItemViewModel(Music item)
        {
            _item = item;
        }

        public long Id => _item.Id;

        public string Name => _item.Name;

        public string Author => _item.Author;

        public int AgreedNum => _item.AgreedNum;

        public int DownLoadNum => _item.DownLoadNum;

        public int TalkNum => _item.TalkNum;

        public MusicReviewEnum Review => _item.Review;

        private Bitmap? _cover;

        public Bitmap? Cover
        {
            get => _cover;
            private set => this.RaiseAndSetIfChanged(ref _cover, value);
        }

        public async Task LoadCover()
        {
            await using (var imageStream = await _item.LoadCoverBitmapAsync())
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
            }
        }
    }
}
