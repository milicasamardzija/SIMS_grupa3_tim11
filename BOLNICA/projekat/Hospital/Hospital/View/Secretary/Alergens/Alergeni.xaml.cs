using Hospital.Controller;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
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

namespace Hospital.Sekretar
{
    public partial class Alergeni : Window
    {
    
       
        public MedicalRecordDTO record;
        public PatientDTO patient;
        public ObservableCollection<PatientDTO> listPatient;
        public ObservableCollection<MedicalRecordDTO> listRecord;
        public MedicalRecordController controller;
        int index;
        public int id;

        public ObservableCollection<AlergensDTO> listAllAlergens
        {
            get;
            set;
        }
        public ObservableCollection<AlergensDTO> listAlergens
        {
            get;
            set;
        }
        public Alergeni(ObservableCollection<PatientDTO> list, PatientDTO selectedPatient, int sel)
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new MedicalRecordController();
            id = selectedPatient.Id;
          //  MessageBoxResult res= MessageBox.Show(Convert.ToString(id));
            record = controller.findRecordById(id);
           // MessageBoxResult res1 = MessageBox.Show(Convert.ToString(record.Name));
            //MessageBoxResult res2 = MessageBox.Show(Convert.ToString(record.MedicalRecordId));

            listAllAlergens = loadJasonAllAlergens();
            listAlergens = loadPatientAlergens(id);

            listPatient = list;

            foreach (PatientDTO p in listPatient)
            {
                if (p.Equals(selectedPatient))
                {
                    patient = p;
                    break;
                }
            }

            index = sel;

        }

        public ObservableCollection<AlergensDTO> loadJasonAllAlergens()
        {
            return controller.getAllAlergens();
        }

        public ObservableCollection<AlergensDTO> loadPatientAlergens(int idPatient)
        {
            return controller.loadPatientAlergens(idPatient);
        }

        private void AddAlergens(object sender, RoutedEventArgs e)
        { if (svi.SelectedItem != null)
            {
                listAlergens.Add((AlergensDTO)svi.SelectedItem);
                listAllAlergens.Remove((AlergensDTO)svi.SelectedItem);
            } else {
                MessageBoxResult result = MessageBox.Show("Niste odabrali alergen!");
            }
        }

      

        private void RemoveAlergen(object sender, RoutedEventArgs e)
        {
            listAlergens.Remove((AlergensDTO)selected.SelectedItem);
        }

        private void saveAlergens(object sender, RoutedEventArgs e)
        {
            MedicalRecordDTO promeniM = controller.findRecordById(id);
            promeniM.Alergens = listAlergens;
            controller.deleteRecordById(id);
            controller.saveMedicalRecord(promeniM);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
