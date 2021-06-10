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
using Hospital.Model;
using Newtonsoft.Json;
using System.IO;
using Hospital.FileStorage.Interfaces;
using Hospital.DTO;
using Hospital.Controller;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for EditDialog.xaml
    /// </summary>
    public partial class EditDialog : Window
    {
        public ObservableCollection<CheckupDTO> listCheckup;
        public CheckupDTO checkup;
        public CheckupController checkupController = new CheckupController();
        public int indexCheckup;

        public EditDialog(ObservableCollection<CheckupDTO> list, CheckupDTO selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            checkup = selectedCheckup;
            indexCheckup = selectedIndex;

            durationText.SelectedText = Convert.ToString(selectedCheckup.Duration);
            comboBox.SelectedIndex = (int)selectedCheckup.Type;
            patientBox.SelectedText = Convert.ToString(selectedCheckup.IdPatient);
            idRoom.SelectedText = Convert.ToString(selectedCheckup.IdRoom);

            CalendarDateRange kalendar = new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1));
            datePick.BlackoutDates.Add(kalendar);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }
       
        private void button_Click(object sender, RoutedEventArgs e)
        {
            checkupController.changeCheckup(checkup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
