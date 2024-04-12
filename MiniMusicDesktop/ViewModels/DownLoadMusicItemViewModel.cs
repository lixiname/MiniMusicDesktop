using Avalonia.Media.Imaging;
using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.Common.Enum;
using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class DownLoadMusicItemViewModel : ViewModelBase
    {
        private readonly Music _item;
        public DownLoadMusicItemViewModel(Music item)
        {
            _item = item;
        }

        public long Id => _item.Id;

        public string Title => _item.Name;

        public string Size => readSize();

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

        private string readSize()
        {
            return 3.ToString();
        }
    }
}
