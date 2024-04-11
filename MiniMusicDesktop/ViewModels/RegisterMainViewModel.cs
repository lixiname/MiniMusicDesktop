using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reactive;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniMusicDesktop.ViewModels
{
    public class RegisterMainViewModel : ViewModelBase
    {

        private string _password = string.Empty;

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
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

        private string _phone = string.Empty;

        public string Phone
        {
            get => _phone;
            set => this.RaiseAndSetIfChanged(ref _phone, value);
        }

        


        public ReactiveCommand<Unit, User> RegisterCommand { get; }
        public ReactiveCommand<Unit, Unit> QuitCommand { get; }
        public RegisterMainViewModel()
        {
            //var isUIdInputValid = this.WhenAnyValue(
            //x=>string.IsNullOrEmpty(x.Password));
            
            RegisterCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var resData = await User.RegisterAsync(userId: UId, password: Password,
                email: Email, phone:Phone,profilePictureUrl:ProfilePictureUrl, name: Name);
                return resData;
                
            });
            QuitCommand = ReactiveCommand.Create(() => { });
            
        }
    }
}
