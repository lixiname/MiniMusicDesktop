using MiniMusicDesktop.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reactive;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace MiniMusicDesktop.ViewModels
{
    public class LoginMainViewModel: ViewModelBase
    {
        private string _password=string.Empty;

        public string Password
        {
            get =>_password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        private string _uId = string.Empty;

        public string UId
        {
            get => _uId;
            set => this.RaiseAndSetIfChanged(ref _uId, value);
        }

        private bool _isOptionManagmentChecked;
        public bool IsOptionManagmentChecked
        {
            get => _isOptionManagmentChecked;
            set => this.RaiseAndSetIfChanged(ref _isOptionManagmentChecked, value);
        }

        private bool _isOptionUserChecked;
        public bool IsOptionUserChecked
        {
            get => _isOptionUserChecked;
            set => this.RaiseAndSetIfChanged(ref _isOptionUserChecked, value);
        }

        public ReactiveCommand<Unit, InfoProfile> LoginCommand { get; }
        public ReactiveCommand<Unit, Unit> QuitCommand { get; }
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public void InitTable(User newItem)
        {
            Password = newItem.Password;
            UId = newItem.UserId;
        }


        public LoginMainViewModel()
        {

            //var isUIdInputValid = this.WhenAnyValue(
            //x=>string.IsNullOrEmpty(x.Password));
            UId = "2024222213";
            Password = "123456";
            //management
            //UId = "00001";
            //Password = "123";
            LoginCommand = ReactiveCommand.CreateFromTask(async() =>
            {
                if (IsOptionUserChecked)
                {
                    
                    //Int32.Parse(UId)
                    var resData =await User.LoginAsync(userId: UId, password:Password);
                    var infoProfile=new InfoProfile
                    {
                        Id=resData.Id,
                        Password=resData.Password,
                        InfoTypes = resData.InfoTypes,
                        LoginSuccess=resData.LoginSuccess,
                        Email = resData.Email,
                        Phone=resData.Phone,
                        ProfilePictureUrl= resData.ProfilePictureUrl,
                        Name=resData.Name,
                        UserId = resData.UserId,
                    };

                    return infoProfile;
                }
                else
                {
                    var resData = await ManagmentUser.LoginAsync(userId: UId, password: Password);
                    var infoProfile = new InfoProfile
                    {
                        Id = resData.Id,
                        Password = resData.Password,
                        InfoTypes = resData.InfoTypes,
                        LoginSuccess = resData.LoginSuccess,
                        Email = resData.Email,
                        Phone = resData.Phone,
                        ProfilePictureUrl = resData.ProfilePictureUrl,
                        Name = resData.Name,
                        UserId = resData.UserId,
                    };
                    return infoProfile;
                }
            });
            QuitCommand = ReactiveCommand.Create(() =>{});
            RegisterCommand = ReactiveCommand.Create(() => { });
        }
    }
}
