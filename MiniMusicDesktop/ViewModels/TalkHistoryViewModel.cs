using MiniMusicDesktop.Models.Common.Const;
using MiniMusicDesktop.Models.Common.Enum;
using MiniMusicDesktop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniMusicDesktop.ViewModels;

public class TalkHistoryViewModel : ViewModelBase
{
    
    public ObservableCollection<TalkHistoryItemViewModel> SearchResults { get; } = new();

    private TalkHistoryItemViewModel? _selectedItem;
    public TalkHistoryItemViewModel? SelectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
    }
    public TalkHistoryViewModel()
    {
        ChangeUserStateCommand = ReactiveCommand.Create(() =>
        {
            return SelectedItem;
        });
        DoSearch();

    }

    private async void DoSearch()
    {

        SearchResults.Clear();
        var userCache=User.ReadLocalCache();
        var talks = await Music.SearchSingleUserTalkAsync(userCache.Id);

        foreach (var item in talks)
        {
            var vm = new TalkHistoryItemViewModel(item);
            SearchResults.Add(vm);
        }
        //LoadCovers();
    }
    private async void LoadCovers()
    {
        foreach (var item in SearchResults.ToList())
        {
            await item.LoadCover();

        }
    }

    public ReactiveCommand<Unit, TalkHistoryItemViewModel?> ChangeUserStateCommand { get; }
}
