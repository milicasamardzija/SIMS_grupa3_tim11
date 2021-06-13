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
using Hospital.DTO;
using Hospital.Controller;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PregledPacijenata.xaml
    /// </summary>
    public partial class PregledPacijenata : Window
    {
        
        public ObservableCollection<PatientDTO> ListPatient
        {
            get;
            set;
        }

        public PatientController controller = new PatientController();

        public PregledPacijenata()
        {
            InitializeComponent();
            this.DataContext = this;
            ListPatient = new ObservableCollection<PatientDTO>(controller.getAll());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PrikaziKartonPacijenta showMedicalRecord = new PrikaziKartonPacijenta(ListPatient, (PatientDTO)Pacijenti.SelectedItem, Pacijenti.SelectedIndex);
            showMedicalRecord.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
