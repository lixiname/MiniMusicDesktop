using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniMusicDesktop.ViewModels
{
    public class LoginMainViewModel : ViewModelBase
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

        
    

    public ReactiveCommand<Unit, User> LoginCommand { get; }
        public ReactiveCommand<Unit, Unit> QuitCommand { get; }

        public LoginMainViewModel()
        {
            //var isUIdInputValid = this.WhenAnyValue(
            //x=>string.IsNullOrEmpty(x.Password));
            
            LoginCommand = ReactiveCommand.CreateFromTask(async() =>
            {
                if (IsOptionUserChecked)
                {
                    var resData=await User.LoginAsync(id: Int32.Parse(UId), password:Password);
                    return resData;
                }
                else
                {
                    var resData = await User.LoginAsync(id: Int32.Parse(UId), password: Password);
                    return resData;
                }
            });
            QuitCommand = ReactiveCommand.Create(() =>{});
        }
    }
}
