using Hospital.Model;
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
    /// Interaction logic for ObrisiTermin.xaml
    /// </summary>
    public partial class ObrisiTermin : Window
    {
        public ObservableCollection<Appointment> appointmentList;
        public int index;
        public int id;
        public ObrisiTermin(ObservableCollection<Appointment> list, Appointment selectedApp, int selectedIndex)
        {
            InitializeComponent();
            appointmentList = list;
            id = selectedApp.Id;
            index = selectedIndex;
        }

        private void da_Click(object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage storage = new AppointmentFileStorage("./../../../../Hospital/files/termini.json");
            storage.DeleteById(id);
            appointmentList.RemoveAt(index);
            FunctionalityFileStorage funkcionalnosti = new FunctionalityFileStorage("./../../../../Hospital/files/count.json");
            Functionality funkcionalnost = new Functionality(DateTime.Now, id, "brisanje");
            funkcionalnosti.Save(funkcionalnost);


            this.Close();
        }

        private void ne_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
