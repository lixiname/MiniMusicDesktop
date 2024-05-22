using MiniMusicDesktop.Models;
using MiniMusicDesktop.Models.Common.Enum;
using MiniMusicDesktop.Models.DTO;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMusicDesktop.ViewModels
{
    public class BarChartViewModel : ViewModelBase
    {



        private MonthEnum _comboBoxMonthSelectedIndex = MonthEnum.January;
        public MonthEnum ComboBoxMonthSelectedIndex
        {
            get => _comboBoxMonthSelectedIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _comboBoxMonthSelectedIndex, value);

            }
        }
        private YearEnum _comboBoxYearSelectedIndex = YearEnum.Year2024;
        public YearEnum ComboBoxYearSelectedIndex
        {
            get => _comboBoxYearSelectedIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref _comboBoxYearSelectedIndex, value);

            }
        }
        public async Task<List<MusicAgreedTopSortDTO>> ChangeBarContentAsync()
        {
            var resList = await Music.SearchBarChartAsync(ComboBoxYearSelectedIndex, ComboBoxMonthSelectedIndex);
            return resList;
        }
    }
}
