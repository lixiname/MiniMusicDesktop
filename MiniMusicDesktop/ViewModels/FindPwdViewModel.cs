using Avalonia.Controls.Notifications;
using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniMusicDesktop.ViewModels
{
    public class FindPwdViewModel : ViewModelBase
    {

        private string _password = string.Empty;

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }


        private string _passwordRepeat = string.Empty;

        public string PasswordRepeat
        {
            get => _passwordRepeat;
            set => this.RaiseAndSetIfChanged(ref _passwordRepeat, value);
        }
        
        private string _captchaCode = string.Empty;

        public string CaptchaCode
        {
            get => _captchaCode;
            set => this.RaiseAndSetIfChanged(ref _captchaCode, value);
        }
        

        public ICommand CaptchaCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetPwdCommand { get; }

        private InfoProfile _infoProfile;
        public InfoProfile InfoProfile
        {
            get => _infoProfile;
            set => this.RaiseAndSetIfChanged(ref _infoProfile, value);
        }

        private string _emailRandomId;
        public string EmailRandomId
        {
            get => _emailRandomId;
            set => this.RaiseAndSetIfChanged(ref _emailRandomId, value);
        }

        
        public FindPwdViewModel(InfoProfile user)
        {
            
            _infoProfile = user;
            _currentEmail = user.Email;
            CaptchaCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                //mock DI test
                InfoProfile.Email = "2729801553@qq.com";
                var emailRandomId=await User.EmailCaptchaAsync(InfoProfile.Email);
                EmailRandomId= emailRandomId;
                //WaitSecondToRepeatGetEmailCode();
            });
            ResetPwdCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                if(CaptchaCode!="")
                {
                    var userInfo = await User.ResetPwdAsync(InfoProfile.UserId, EmailRandomId, CaptchaCode, Password);
                }
                else
                {
                    throw new Exception("captchaCode empty");
                }
                
            });
        }


        private string _currentEmail = string.Empty;
        public string CurrentEmail

        {
            get => _currentEmail
;
            set => this.RaiseAndSetIfChanged(ref _currentEmail, value);
        }

        private bool _getCaptchaEnabled =true;
        public bool GetCaptchaEnabled
        {
            get => _getCaptchaEnabled;
            set => this.RaiseAndSetIfChanged(ref _getCaptchaEnabled, value);
        }

        private string _secondWait= Assets.Resources.GetCaptchaText;
        public string SecondWaitGetCaptcha
        {
            get => _secondWait;
            set => this.RaiseAndSetIfChanged(ref _secondWait, value);
        }
        public async Task WaitSecondToRepeatGetEmailCode()
        {
            GetCaptchaEnabled=false;
            //for (int i = 6000; i > 0; i--)
            //{

            //    SecondWaitGetCaptcha = i.ToString()+" Second";
            //    //Thread.Sleep(1000);
            //    Console.WriteLine(SecondWaitGetCaptcha);

            //}
            SecondWaitGetCaptcha = Assets.Resources.GetCaptchaText;
            //GetCaptchaEnabled=true;
        }
       
    }
}
