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
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using Hospital.Model;
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for AddDialog.xaml
    /// </summary>
    public partial class AddDialog : Window
    {
        public ObservableCollection<CheckupDTO> listCheckup;
        public int idD;
        public CheckupDTO checkup = new CheckupDTO();
        public CheckupController controller = new CheckupController();

        public AddDialog(ObservableCollection<CheckupDTO> list, int idDoctor)
        {
            InitializeComponent();
            listCheckup = list;
            idD = idDoctor;

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            dateP.BlackoutDates.Add(kalendar);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            controller.addCheckup(checkup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
