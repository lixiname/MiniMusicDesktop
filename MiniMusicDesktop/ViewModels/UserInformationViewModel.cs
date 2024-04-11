using MiniMusicDesktop.Models;
using MiniMusicDesktop.Models.Common;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniMusicDesktop.ViewModels
{
    public class UserInformationViewModel : ViewModelBase
    {
        


        private string _oldPassword = string.Empty;

        public string OldPassword
        {
            get => _oldPassword;
            set => this.RaiseAndSetIfChanged(ref _oldPassword, value);
        }


        private string _newPassword = string.Empty;

        public string NewPassword
        {
            get => _newPassword;
            set => this.RaiseAndSetIfChanged(ref _newPassword, value);
        }


        private bool _passwordIsEnabled = false;

        public bool PasswordIsEnabled
        {
            get => _passwordIsEnabled;
            set => this.RaiseAndSetIfChanged(ref _passwordIsEnabled, value);
        }

        private string _uId = string.Empty;

        public string UId
        {
            get => _uId;
            set => this.RaiseAndSetIfChanged(ref _uId, value);
        }


        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        private bool _nameIsEnabled = false;

        public bool NameIsEnabled
        {
            get => _nameIsEnabled;
            set => this.RaiseAndSetIfChanged(ref _nameIsEnabled, value);
        }


        private string _profilePictureUrl = string.Empty;

        public string ProfilePictureUrl
        {
            get => _profilePictureUrl;
            set => this.RaiseAndSetIfChanged(ref _profilePictureUrl, value);
        }

        private string _email = string.Empty;

        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        private bool _emailIsEnabled = false;

        public bool EmailIsEnabled
        {
            get => _emailIsEnabled;
            set => this.RaiseAndSetIfChanged(ref _emailIsEnabled, value);
        }


        private bool _phoneIsEnabled = false;
        public bool PhoneIsEnabled
        {
            get => _phoneIsEnabled;
            set => this.RaiseAndSetIfChanged(ref _phoneIsEnabled, value);
        }


        private string _phone = string.Empty;

        public string Phone
        {
            get => _phone;
            set => this.RaiseAndSetIfChanged(ref _phone, value);
        }

        public ICommand ChangePhoneCommand { get; }
        public ICommand ChangePasswordCommand { get; }
        public ICommand ChangeEmailCommand { get; }
        public ICommand ChangeNameCommand { get; }
        public ReactiveCommand<Unit, Unit> ChangeInfoCommand { get; }
        

        public UserInformationViewModel(InfoProfile infoProfile)
        {
            Email=infoProfile.Email ;
            Phone=infoProfile.Phone;
            Name = infoProfile.Name;
            UId = infoProfile.UserId;


            ChangePhoneCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                PhoneIsEnabled = !PhoneIsEnabled;
            });
            ChangePasswordCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                PasswordIsEnabled = !PasswordIsEnabled;
            });
            ChangeEmailCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                EmailIsEnabled = !EmailIsEnabled;
            });
            ChangeNameCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                NameIsEnabled = !NameIsEnabled;
            });

            ChangeInfoCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var info=await User.UpdateInfoAsync(UId,OldPassword,NewPassword,Email,
                    Phone,ProfilePictureUrl,Name);
                if (info.LoginSuccess == LoginStateEnum.Login)
                {
                    Email = info.Email;
                    Phone = info.Phone;
                    Name = info.Name;
                    ProfilePictureUrl = info.ProfilePictureUrl;
                }
                else
                {
                    throw new Exception("update error");
                }

            });

            
        }
        
    }
}
