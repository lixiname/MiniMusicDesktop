using Avalonia.Controls;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.ViewModels;
using ReactiveUI;
using System;

namespace MiniMusicDesktop.Views
{
    public partial class MessageSuccessView : ReactiveWindow<MessageSuccessViewModel>
    {
        
        public MessageSuccessView()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.SubmitCommand.Subscribe()));
        }
    }
}
