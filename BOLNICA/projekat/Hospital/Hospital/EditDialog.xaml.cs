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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for EditDialog.xaml
    /// </summary>
    public partial class EditDialog : Window
    {

        public ObservableCollection<Checkup> listCheckup;
        public Checkup checkup;
        public int index;

        public EditDialog(ObservableCollection<Checkup> list, Checkup selectedCheckup, int selectedIndex)
        {
            InitializeComponent();
            listCheckup = list;
            checkup = selectedCheckup;
            index = selectedIndex;
            datePick.SelectedDate = Convert.ToDateTime(selectedCheckup.Date);
            //datePick.DisplayDate = new DateTime(2021, 04, 17);
            timeText.SelectedText = Convert.ToString(selectedCheckup.Time);
            durationText.SelectedText = Convert.ToString(selectedCheckup.Duration);
            comboBox.SelectedIndex = (int)selectedCheckup.Type;
            //patientBox.SelectedText = Convert.ToString(selectedCheckup.patient);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        public int generisiID()
        {
            int ret = 0;
            CheckupFileStorage storage = new CheckupFileStorage();
            List<Checkup> allCheckups = storage.GetAll();
            foreach (Checkup ch in allCheckups)
            {
                foreach (Checkup checkup in allCheckups)
                {
                    if (ret == checkup.IdCh)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CheckupFileStorage st = new CheckupFileStorage();
            checkup.Date = datePick.DisplayDate;
            checkup.Time = Convert.ToString(timeText.Text);
            checkup.Duration = Convert.ToDouble(durationText.Text);
            checkup.Type = (CheckupType)comboBox.SelectedIndex;
            // checkup.patient = patientBox.Text;
            int ida = 1;
            int idc = generisiID();

             listCheckup[index] = new Checkup(ida, idc, datePick.DisplayDate, Convert.ToString(checkup.Time),  Convert.ToDouble(checkup.Duration), 
            (CheckupType)checkup.Type,checkup.Patient, checkup.Doctor);

            st.DeleteById(Convert.ToInt16(durationText.Text));
            st.Save(checkup);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
