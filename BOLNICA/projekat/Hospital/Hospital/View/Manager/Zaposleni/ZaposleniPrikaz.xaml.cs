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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.FileStorage.Interfaces;

namespace Hospital.View.Manager.Zaposleni
{
    public partial class ZaposleniPrikaz : UserControl
    {
        public ObservableCollection<Doctor> doctors { get; set; }
        private IDoctorFileStorage storage = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
        public ZaposleniPrikaz()
        {
            this.DataContext = this;
            this.doctors = new ObservableCollection<Doctor>(storage.GetAll());
            InitializeComponent();
            DoktoriFrame.NavigationService.Navigate(new Izvestaj());
        }
    }
}
