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
    
       
        public MedicalRecord record;
        public Patient patient;
        public ObservableCollection<Patient> listPatient;
        public ObservableCollection<MedicalRecord> listRecord;
        int index;
        public int id;


        public ObservableCollection<Alergens> listAllAlergens
        {
            get;
            set;
        }
        public ObservableCollection<Alergens> listAlergens
        {
            get;
            set;
        }
        public Alergeni(ObservableCollection<Patient> list, Patient selectedPatient, int sel)
        {
            InitializeComponent();
            this.DataContext = this;
            id = selectedPatient.Id;
            MedicalRecordsFileStorage mfs = new MedicalRecordsFileStorage();
            record = mfs.FindById(id);
          
            listAllAlergens = loadJasonAllAlergens();
            listAlergens = loadPatientAlergens();

            listPatient = list;

            foreach (Patient p in listPatient)
            {
                if (p.Equals(selectedPatient))
                {
                    patient = p;
                    break;
                }
            }

            index = sel;

        }

        public ObservableCollection<Alergens> loadJasonAllAlergens()
        {
            AlergensFileStorage afs = new AlergensFileStorage();
            ObservableCollection<Alergens> ret = new ObservableCollection<Alergens>(afs.GetAll());

            return ret;
        }

        public ObservableCollection<Alergens> loadPatientAlergens()
        {
           
            ObservableCollection<Alergens> a = new ObservableCollection<Alergens>();
            MedicalRecordsFileStorage mStorage = new MedicalRecordsFileStorage();
            MedicalRecord prikaziAlergene = mStorage.FindById(id);
           
            foreach (Alergens al in record.Alergens)
            {
            
                a.Add(al);
            }
            return a;
           
        }

        private void AddAlergens(object sender, RoutedEventArgs e)
        {
            AlergensFileStorage afs = new AlergensFileStorage();

            listAlergens.Add((Alergens)svi.SelectedItem);
            listAllAlergens.Remove((Alergens)svi.SelectedItem);
         

        }

      

        private void RemoveAlergen(object sender, RoutedEventArgs e)
        {
            AlergensFileStorage afs = new AlergensFileStorage();
            listAlergens.Remove((Alergens)selected.SelectedItem);
        }

        private void saveAlergens(object sender, RoutedEventArgs e)
        {
            
            MedicalRecordsFileStorage mStorage = new MedicalRecordsFileStorage();
            MedicalRecord promeniM = mStorage.FindById(id);

            promeniM.alergens = listAlergens;

            mStorage.DeleteById(id);
            mStorage.Save(promeniM);

            this.Close();
        }
    }
}
