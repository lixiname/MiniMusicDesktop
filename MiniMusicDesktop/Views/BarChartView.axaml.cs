using Avalonia.Controls;
using ScottPlot.Avalonia;
using ScottPlot;
using Avalonia.ReactiveUI;
using MiniMusicDesktop.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using System.Collections;
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
            double[] dataX = { 1, 2, 3, 4, 5 };
            //double[] dataY = { 1, 4, 9, 16, 25 };
            var dataY = new ArrayList();
            foreach(var item in musicList)
            {
                dataY.Add(item.Count);
            }
            var avaPlot1 = this.Find<AvaPlot>("AvaPlot1");
            avaPlot1.Plot.Add.Scatter(dataX, dataY.ToArray());
            //avaPlot1.Plot.AddSignal();
            avaPlot1.Refresh();
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
    }
}
