using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class MessageSuccessViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> SubmitCommand { get; }
        public ReactiveCommand<Unit, Unit> QuitCommand { get; }
        public MessageSuccessViewModel()
        {
            SubmitCommand = ReactiveCommand.Create(() =>
            {

            });
            QuitCommand = ReactiveCommand.Create(() =>
            {

            });



        }
    }
}
