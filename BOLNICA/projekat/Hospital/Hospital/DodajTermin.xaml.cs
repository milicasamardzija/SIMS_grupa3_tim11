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
    /// Interaction logic for DodajTermin.xaml
    /// </summary>
    public partial class DodajTermin : Window
    {

        public ObservableCollection<Appointment> appointmentList;
        public DodajTermin(ObservableCollection<Appointment> lista)
        {
            InitializeComponent();
            appointmentList = lista;

        }

        private void add_appointment(object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage storage = new AppointmentFileStorage();

            Appointment newapp = new Appointment(Convert.ToInt32(idText.Text),Convert.ToString(dateText.Text), Convert.ToString(timeText.Text),Convert.ToDouble(durationText.Text),Convert.ToString(doctorText.Text));

            storage.Save(newapp);
            appointmentList.Add(newapp);

            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
