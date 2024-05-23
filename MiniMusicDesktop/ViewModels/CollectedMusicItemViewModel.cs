using Avalonia.Media.Imaging;
using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.Common.Enum;
using MiniMusicDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace MiniMusicDesktop.ViewModels
{
    public class CollectedMusicItemViewModel : ViewModelBase
    {
        public readonly Music _item;
        public CollectedMusicItemViewModel(Music item)
        {
            _item = item;
        }

        public long Id => _item.Id;

        public string Name => _item.Name;

        public string Author => _item.Author;

        public int AgreedNum => _item.AgreedNum;

        public int DownLoadNum => _item.DownLoadNum;

        public int TalkNum => _item.TalkNum;

        public int UsingNum => _item.UsingNum;

        public string MusicType
        {
            get
            {
                switch (_item.MusicType)
                {
                    case MusicTypeEnum.Type0: return MusicTypeConst.Type0;
                    case MusicTypeEnum.Type1: return MusicTypeConst.Type1;
                    case MusicTypeEnum.Type2: return MusicTypeConst.Type2;
                    case MusicTypeEnum.Type3: return MusicTypeConst.Type3;
                    default: return MusicTypeConst.Type0;
                }


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
            await using (var imageStream = await _item.LoadCoverBitmapAsync())
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
            }
        }
    }
}
