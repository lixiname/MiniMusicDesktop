using Avalonia.Controls;
using ScottPlot.Avalonia;
using ScottPlot;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using System.Collections;
using ScottPlot.TickGenerators.TimeUnits;
using System;
namespace MiniMusicDesktop.Views
{
    public partial class BarChartView : ReactiveUserControl<BarChartViewModel>
    {
        public BarChartView()
        {
            InitializeComponent();
            
            //Plot myPlot = new();
            //var myScatter = myPlot.Add.Scatter(dataX, dataY);
            //myScatter.Color = Colors.Green.WithOpacity(.2);
            
            
            //var canvas = this.FindControl<Canvas>("plotCanvas");
            //myPlot.Render(canvas);
        }
        public async void Button_click_ChangeChart(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var musicList = await ViewModel!.ChangeBarContentAsync();
            var dataX = new ArrayList();
            var dataY = new ArrayList();
            var avaPlot1 = this.Find<AvaPlot>("AvaPlot1");
            if (musicList.Count > 0)
            {
                for (int i = 0; i < musicList.Count; i++)
                {
                    dataY.Add(musicList[i].Count);
                    dataX.Add(i + 1);
                }

                //avaPlot1.Plot.Add.Bars((System.Collections.Generic.IEnumerable<Bar>)dataY.ToArray());
                //avaPlot1.Plot.AddSignal();
                var year = Convert.ToInt32(ViewModel!.ComboBoxYearSelectedIndex) + 2023;
                var month = Convert.ToInt32(ViewModel!.ComboBoxMonthSelectedIndex) + 1;
                avaPlot1.Plot.Axes.Title.Label.Text = $"{year}{Assets.Resources.YearString} - {month}{Assets.Resources.MonthString}";
                avaPlot1.Plot.Grid.IsVisible = false;
                avaPlot1.Plot.YLabel("Collect-Count");
                avaPlot1.Plot.XLabel("Top-Sort");
                avaPlot1.Plot.Add.Scatter(dataX.ToArray(), dataY.ToArray());
            }
            
            avaPlot1.Refresh();
            //var plt = new Plot();
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //var s = new BarSeries
            //{
            //    Color=Color.FromARGB()
            //};
        }
    }
}
