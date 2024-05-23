using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.Common.Enum;
using MiniMusicDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels;

public class TalkHistoryItemViewModel : ViewModelBase
{
    private TalkDTO _item;
    public TalkHistoryItemViewModel(TalkDTO item)
    {
        _item = item;
    }

    public long Id => _item.TalkId;
    public string UId => _item.TalkUId;

    public string MusicName => _item.MusicName;

    public string ProfilePictureUrl => "";

    public string Email => _item.Email;

    public string Phone => _item.Phone;

    public string TalkContent => _item.Contents;


    public string State
    {
        get
        {
            if (_item.State == UserStateEnum.Valid)
            {
                return UserStateConst.Valid;
            }
            else
            {
                return UserStateConst.InValid;
            }

        }
    }

    public string Valid
    {
        get
        {
            if (_item.State == UserStateEnum.Valid)
            {
                return UserStateManagementConst.InValid;
            }
            else
            {
                return UserStateManagementConst.Valid;
            }

        }
    }


    public async Task LoadCover()
    {
        //await using (var imageStream = await _item.LoadCoverBitmapAsync())
        //{
        //    Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
        //}
    }
}
