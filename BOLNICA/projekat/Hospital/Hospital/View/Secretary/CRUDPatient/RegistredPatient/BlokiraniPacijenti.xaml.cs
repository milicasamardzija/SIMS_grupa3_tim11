using Hospital.Controller;
using Hospital.DTO;
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

namespace Hospital.View.Secretary.CRUDPatient.RegistredPatient
{
    /// <summary>
    /// Interaction logic for BlokiraniPacijenti.xaml
    /// </summary>
    public partial class BlokiraniPacijenti : Window
    {
        public ObservableCollection<PatientDTO> listBlocked { get; set; }
        public PatientController patientController = new PatientController();
        
        public BlokiraniPacijenti()
        {
            InitializeComponent();
            this.DataContext = this;
            listBlocked = loadBlockedPatient();
        }

        public ObservableCollection<PatientDTO> loadBlockedPatient()
        {
            ObservableCollection<PatientDTO> listBlocked= new ObservableCollection<PatientDTO>( patientController.loadBlockedPatients());
            return listBlocked;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(pretraga.Text != "")
            {
                PrikazPacijenata.ItemsSource = patientController.patientBySurname(pretraga.Text);
            }else
            {
                PrikazPacijenata.ItemsSource = patientController.loadBlockedPatients();

            }
        }

        private void OdblokirajBtn(object sender, RoutedEventArgs e)
        {
            if ((PatientDTO)PrikazPacijenata.SelectedItem != null)
            {
                patientController.unblockPatient((PatientDTO)PrikazPacijenata.SelectedItem);
                OdblokirajPacijenta odblokiranNote = new OdblokirajPacijenta(listBlocked, PrikazPacijenata.SelectedIndex);
                odblokiranNote.Show();

            } else
            {
                MessageBoxResult mess = MessageBox.Show("Morate odabrati pacijenta!");
            }
        }
        private void DeclineBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
