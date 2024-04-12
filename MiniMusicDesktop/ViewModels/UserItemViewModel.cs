using Avalonia.Media.Imaging;
using MiniMusicDesktop.Models;
using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.Common.Enum;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class UserItemViewModel : ViewModelBase
    {
        private readonly User _item;
        public UserItemViewModel(User item)
        {
            _item = item;
        }

        public long Id => _item.Id;
        public string Password=> "长度"+_item.Password.Length.ToString();
       
        public string UId => _item.UserId;
        
        public string Name => _item.Name;
       
        public string ProfilePictureUrl => _item.ProfilePictureUrl;
       
        public string Email => _item.Email;

        public string Phone=>_item.Phone;

       
        public string State
        {
            get
            {
                if (_item.State==UserStateEnum.Valid)
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
