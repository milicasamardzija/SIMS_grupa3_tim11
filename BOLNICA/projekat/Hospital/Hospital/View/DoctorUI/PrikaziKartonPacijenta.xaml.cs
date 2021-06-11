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
using System.IO;
using Hospital.FileStorage.Interfaces;
using Hospital.DTO;
using Hospital.Controller;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PrikaziKartonPacijenta.xaml
    /// </summary>
    public partial class PrikaziKartonPacijenta : Window
    {

        public ObservableCollection<MedicalRecord> MedicalList { get; set; }
        public MedicalRecordController controller = new MedicalRecordController();

        public ObservableCollection<PatientDTO> Pacijenti;
        public PatientDTO patient;
        public int idPatient;

        public PrikaziKartonPacijenta(ObservableCollection<PatientDTO> list, PatientDTO selectedPatient, int selectedIndex)
        {
            InitializeComponent();
            this.DataContext = this;
            Pacijenti = list;
            patient = selectedPatient;
            idPatient = selectedIndex;
            MedicalList = new ObservableCollection<MedicalRecord>(controller.getAll());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
