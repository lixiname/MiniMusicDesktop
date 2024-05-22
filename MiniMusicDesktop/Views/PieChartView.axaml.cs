using Avalonia.Controls;
using ScottPlot.Avalonia;
using ScottPlot;
using System.Collections;
using System;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.ViewModels;
using PCLUntils.Objects;

namespace MiniMusicDesktop.Views
{
    public partial class PieChartView: ReactiveUserControl<PieChartViewModel>
    {
        public PieChartView()
        {
            InitializeComponent();
            var avaPlot1 = this.Find<AvaPlot>("AvaPlot1");
            avaPlot1.Plot.Grid.IsVisible = false;
            avaPlot1.Refresh();

        }
        public async void Button_click_ChangeChart(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var musicList = await ViewModel!.ChangeBarContentAsync(); 
            var dataX = new ArrayList();
            var dataY = new ArrayList();
            var avaPlot1 = this.Find<AvaPlot>("AvaPlot1");
            if (musicList.Count>0)
            {
                for (int i = 0; i < musicList.Count; i++)
                {
                    dataY.Add(musicList[i].Count);
                    dataX.Add(i + 1);
                }
                avaPlot1.Plot.Add.Scatter(dataX.ToArray(), dataY.ToArray());
                var year = Convert.ToInt32(ViewModel!.ComboBoxYearSelectedIndex) + 2023;
                var month = Convert.ToInt32(ViewModel!.ComboBoxMonthSelectedIndex) + 1;
                avaPlot1.Plot.Axes.Title.Label.Text = $"{year}{Assets.Resources.YearString} - {month}{Assets.Resources.MonthString}";
                avaPlot1.Plot.Grid.IsVisible = false;
                avaPlot1.Plot.YLabel("Download-Count");
                avaPlot1.Plot.XLabel("Top");
                avaPlot1.Plot.Axes.SetLimits(dataX[0].ToInt32(), dataX[dataX.Count - 1].ToInt32());
            }
            
            avaPlot1.Plot.Grid.IsVisible = false;
            avaPlot1.Refresh();
        }
    }
}
