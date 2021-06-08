using Hospital.Controller;
using LiveCharts;
using LiveCharts.Wpf;

using Syncfusion.Pdf;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;

using System.Data;
using MindFusion.Svg;

namespace Hospital.View.Secretary.AppOrganisation
{
    /// <summary>
    /// Interaction logic for Analitika.xaml
    /// </summary>
    public partial class Analitika : Page
    {
      
        private CheckupController controller;

        public Analitika()
        {
            InitializeComponent();
            DataContext = this;
            Cartesian();
            PieChart();
            controller = new CheckupController();
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
        public object PdfFontFamily { get; private set; }

        private void generateReport(object sender, RoutedEventArgs e)
        {
            int operations = controller.counterOperation((DateTime)odDate.SelectedDate, (DateTime)doDate.SelectedDate);
            int checkups = controller.counterCheckup((DateTime)odDate.SelectedDate, (DateTime)doDate.SelectedDate);

            
            DateTime p = (DateTime)odDate.SelectedDate;
            string pocetak = p.ToString("dd.MM.yyyy.");
            DateTime k = (DateTime)doDate.SelectedDate;
            string kraj = k.ToString("dd.MM.yyyy.");

           
         

             using (PdfDocument doc = new PdfDocument())
              {
                

                  //Add a page.
                  PdfPage page = doc.Pages.Add();

                  // Create a PdfLightTable.
                  PdfLightTable pdfLightTable = new PdfLightTable();

                  // Initialize DataTable to assign as DateSource to the light table.
                  DataTable table = new DataTable();


                //Include columns to the DataTable.
                table.Columns.Add("Operacije");

                
                  String zaglavlje = "IZVESTAJ O ZAKAZANIM OPERACIJAMA I PREGLEDIMA U PERIODU OD " + pocetak + " do "+ kraj;

                  //Include rows to the DataTable.
                  table.Rows.Add(new string[] { zaglavlje });
                  table.Rows.Add(new string[] { "Broj zakazanih operacija je " + Convert.ToString(operations) });
                  table.Rows.Add(new string[] { "Broj zakazanih pregleda je " +  Convert.ToString(checkups) });



                  //Assign data source.
                  pdfLightTable.DataSource = table;

                  //Draw PdfLightTable.
                  pdfLightTable.Draw(page, new PointF(0, 0));

                  //Save the document
                  doc.Save("C:\\Users\\neven\\Desktop\\Izvestaj.pdf");

                  //Close the document

                  doc.Close(true);
              }

              MessageBox.Show("Uspesno kreiran izvestaj!");
          }

        
    }
}
