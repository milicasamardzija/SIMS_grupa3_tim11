using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.View.Secretary.AppOrganisation
{
    /// <summary>
    /// Interaction logic for Analitika.xaml
    /// </summary>
    public partial class Analitika : Page
    {
        public Analitika()
        {
            InitializeComponent();
            DataContext = this;
            Cartesian();
            PieChart();
        }
        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            

        }
        public SeriesCollection SeriesCollection { get; set; }
       
      
        public void Cartesian()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title="Onkologija", Values = new  ChartValues<double>{100,200,100,200 }
                },
                new LineSeries
                {
                    Title="Hirurgija", Values = new  ChartValues<double>{1000,1200,1300,1900 }
                },
                new LineSeries
                {
                    Title="De\u010Dije", Values = new  ChartValues<double>{200,600,100,200 }
                },
                new LineSeries
                {
                    Title="Psihijatrija", Values = new  ChartValues<double>{10,3000,10,20 }
                }

            };
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
