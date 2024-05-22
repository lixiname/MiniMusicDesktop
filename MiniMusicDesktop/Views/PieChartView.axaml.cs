using Avalonia.Controls;
using ScottPlot.Avalonia;
using ScottPlot;
using System.Collections;
using System;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.ViewModels;

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
            //double[] dataX = { 1, 2, 3, 4, 5, 6,7,8,9,10,11,12,13,14,15,16};
            var dataX = new ArrayList();
            var dataY = new ArrayList();
            foreach (var item in musicList)
            {
                dataY.Add(item.Count);
                dataX.Add(item.Day);
            }
            var avaPlot1 = this.Find<AvaPlot>("AvaPlot1");
            avaPlot1.Plot.Add.Scatter(dataX.ToArray(), dataY.ToArray());
            var year = Convert.ToInt32(ViewModel!.ComboBoxYearSelectedIndex) + 2023;
            var month = Convert.ToInt32(ViewModel!.ComboBoxMonthSelectedIndex) + 1;
            //avaPlot1.Plot.Title($"{year}{Assets.Resources.YearString} - {month}{Assets.Resources.MonthString}");
            avaPlot1.Plot.Axes.Title.Label.Text = $"{year}{Assets.Resources.YearString} - {month}{Assets.Resources.MonthString}";
            avaPlot1.Plot.Grid.IsVisible = false;
            avaPlot1.Plot.YLabel("Like-Count");
            avaPlot1.Plot.XLabel("Day");
            //avaPlot1.Plot.Axes.AutoScaleX();
            //avaPlot1.Plot.Axes.AutoScaleY();
            avaPlot1.Plot.Axes.SetLimits(dataX[0].ToInt32(), dataX[dataX.Count - 1].ToInt32());
            var s = new BarSeries
            {

            };
            //avaPlot1.Plot.Style.Background();
            avaPlot1.Refresh();
        }
    }
}
