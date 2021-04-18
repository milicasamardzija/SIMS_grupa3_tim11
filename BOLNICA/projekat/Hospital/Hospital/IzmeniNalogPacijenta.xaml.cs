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

namespace Hospital
{
    public partial class IzmeniNalogPacijenta : Window { 

       public ObservableCollection<Patient> listPatient;
        public Patient patient;
        public int index;
        public MedicalRecord record;

        public int id;
        public IzmeniNalogPacijenta(ObservableCollection<Patient> list, Patient selectedPatient, int sel)
        {
           InitializeComponent();
            listPatient = list;

            foreach (Patient p in listPatient)
            {
                if (p.Equals(selectedPatient))
                {
                    patient = p;
                    break;
                }
            }

         

            listPatient=list;
            index = sel;

            //da bih nasla odgovarajuci karton od tog pacijenta
            id = selectedPatient.PatientId; //patientId=medicalId
            MedicalRecordsFileStorage mfs = new MedicalRecordsFileStorage();
            record = mfs.FindById(id);





            //za nalog
            imeText.SelectedText = selectedPatient.name;
            prezimeText.SelectedText = selectedPatient.surname;
            jmbgText.SelectedText = selectedPatient.jmbg;
            pol.SelectedIndex = (int)selectedPatient.gender; 
            brText.SelectedText = selectedPatient.telephoneNumber;

            datum.SelectedDate = (DateTime)selectedPatient.BirthdayDate;
            brKnjText.SelectedText = Convert.ToString(selectedPatient.IdHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedPatient.PatientId);

            datum.SelectedDate = (DateTime)selectedPatient.birthdayDate;
            brKnjText.SelectedText = Convert.ToString(selectedPatient.IdHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedPatient.PatientId);
            zanimanjeText.SelectedText = selectedPatient.Occupation;
            zastitaText.SelectedIndex = (int)selectedPatient.HealthCareCategory;
            osiguraniktText.SelectedText = selectedPatient.Insurence;
            ulicaText.SelectedText = Convert.ToString(selectedPatient.adress.street);
            broj.SelectedText = Convert.ToString(selectedPatient.adress.streetNumber);
            grad.SelectedIndex = (int)selectedPatient.adress.city;  
            drzava.SelectedIndex = (int)selectedPatient.adress.country;



            //nadjene idformacije i iz njenog kartona 
            alergeni.SelectedText = record.alergens;
            krvnaGrupa.SelectedIndex = (int)record.bloodType; 

            

        }

        private void izmenaPacijentaB(object sender, RoutedEventArgs e)
        {

            PatientFileStorage pfs = new PatientFileStorage();
            Patient promeniP = pfs.FindById(Convert.ToInt16(brKarText.
                Text));
            Patient izbrisiP = pfs.FindById(Convert.ToInt16(brKarText.Text));

            promeniP.name = imeText.Text;
            promeniP.surname = prezimeText.Text;
            promeniP.birthdayDate = (DateTime)datum.SelectedDate;
            promeniP.jmbg = jmbgText.Text;
            promeniP.Occupation = zanimanjeText.Text;
            promeniP.Insurence = osiguraniktText.Text;
            promeniP.gender = (Gender)pol.SelectedIndex;    //ovako ide za combo box
            promeniP.telephoneNumber = brText.Text;

            promeniP.PatientId = Convert.ToInt16(brKarText.Text);
            
            promeniP.IdHealthCard = Convert.ToInt16(brKnjText.Text);
            promeniP.HealthCareCategory = (HealthCareCategory)zastitaText.SelectedIndex;
            promeniP.adress.city =((City)grad.SelectedIndex);
            promeniP.adress.country =(Country)drzava.SelectedIndex;
            promeniP.adress.street = ulicaText.Text;
            promeniP.adress.streetNumber = Convert.ToInt16(broj.Text);


            MedicalRecordsFileStorage mfs = new MedicalRecordsFileStorage();
            MedicalRecord promeniM = mfs.FindById(Convert.ToInt16(brKarText.Text));
            MedicalRecord izbrisiM = mfs.FindById(Convert.ToInt16(brKarText.Text));

            promeniM.name = imeText.Text;
            promeniM.surname = prezimeText.Text;
            promeniM.birthdayDate = (DateTime)datum.SelectedDate;
            promeniM.jmbg = jmbgText.Text;
            promeniM.gender = (Gender)pol.SelectedIndex;
            promeniM.medicalRecordId= Convert.ToInt16(brKarText.Text);
            promeniM.IdHealthCard = Convert.ToInt16(brKnjText.Text);
            promeniM.HealthCareCategory= (HealthCareCategory)zastitaText.SelectedIndex;
            promeniM.bloodType = (BloodType)krvnaGrupa.SelectedIndex;
            promeniM.alergens = alergeni.Text;

            mfs.Delete(izbrisiM);
            mfs.Save(promeniM);


            pfs.Delete(izbrisiP);
            pfs.Save(promeniP);



            this.Close();

        }
        private void odustaniB(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
