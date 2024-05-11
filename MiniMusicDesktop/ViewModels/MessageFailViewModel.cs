using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class MessageFailViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> SubmitCommand { get; }
        public ReactiveCommand<Unit, Unit> QuitCommand { get; }
        public MessageFailViewModel()
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
