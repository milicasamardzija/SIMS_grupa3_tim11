using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzmeniTermin.xaml
    /// </summary>
    public partial class IzmeniTermin : Window
    {
        public ObservableCollection<Appointment> appointmentList;
        public Appointment termin;
        public int index;
        public IzmeniTermin(ObservableCollection<Appointment> list, Appointment selectedApp,int selectedIndex)
        {
            InitializeComponent();

            appointmentList = list;
            termin = selectedApp;
            index = selectedIndex;
            
            idText.SelectedText = Convert.ToString(selectedApp.idA);
            dateText.SelectedText = Convert.ToString(selectedApp.date);
            timeText.SelectedText = Convert.ToString(selectedApp.time);
            durationText.SelectedText = Convert.ToString(selectedApp.duration);
            doctorText.SelectedText = Convert.ToString(selectedApp.doctor);
        }

        private void add_appointment(object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage storage = new AppointmentFileStorage();

            termin.idA = Convert.ToInt32(idText.Text);
            termin.date = Convert.ToString(dateText.Text);
            termin.time = Convert.ToString(timeText.Text);
            termin.duration = Convert.ToDouble(durationText.Text);
            termin.doctor = Convert.ToString(doctorText.Text);


            storage.DeleteById(Convert.ToInt16(idText.Text));
            storage.Save(termin);

            this.Close();
        }

        private void odustani_click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
