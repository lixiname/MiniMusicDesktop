using Avalonia.Controls;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.ViewModels;
using ReactiveUI;
using System;
namespace MiniMusicDesktop.Views
{
    public partial class SearchMusicWindow : ReactiveWindow<SearchMusicViewModel>
    {
        public SearchMusicWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.BuyMusicCommand.Subscribe(Close)));
        }
    }
}
