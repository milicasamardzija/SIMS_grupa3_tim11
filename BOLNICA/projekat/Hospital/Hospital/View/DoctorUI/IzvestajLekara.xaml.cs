using Hospital.Controller;
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
using System.Windows.Shapes;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Drawing;
using System.Data;
using Hospital.TemplateForReports;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzvestajLekara.xaml
    /// </summary>
    public partial class IzvestajLekara : Window
    {
        private ReportController controller;

        public IzvestajLekara()
        {
            InitializeComponent();

            controller = new ReportController();
        }

        private void button1_Click(object sender, RoutedEventArgs e)

        {   controller.CreateDoctorReport((DateTime)datePicker1.SelectedDate, (DateTime)datePicker2.SelectedDate);


           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
