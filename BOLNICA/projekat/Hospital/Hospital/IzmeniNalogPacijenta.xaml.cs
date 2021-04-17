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
    /// <summary>
    /// Interaction logic for IzmeniNalogPacijenta.xaml
    /// </summary>
    public partial class IzmeniNalogPacijenta : Window { 

       public ObservableCollection<Patient> listPatient;
        public ObservableCollection<MedicalRecord> listRecord;
        public Patient patient;
        public int index;
        public MedicalRecord record;
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

            //za nalog
            imeText.SelectedText = selectedPatient.name;
            prezimeText.SelectedText = selectedPatient.surname;
            jmbgText.SelectedText = selectedPatient.jmbg;
           // pol.SelectedIndex = (int)selectedPatient.gender; //ovako se setuje opcija combo box-a
            brText.SelectedText = selectedPatient.telephoneNumber;

            datumText.SelectedText = selectedPatient.birthdate;
            brKnjText.SelectedText = Convert.ToString(selectedPatient.IdHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedPatient.PatientId);

            datum.SelectedDate = (DateTime)selectedPatient.birthdayDate;
            brKnjText.SelectedText = Convert.ToString(selectedPatient.idHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedPatient.patientId);
            zanimanjeText.SelectedText = selectedPatient.occupation;
            zastitaText.SelectedIndex = (int)selectedPatient.healthCareCategory;
            osiguraniktText.SelectedText = selectedPatient.insurence;
            ulicaText.SelectedText = Convert.ToString(selectedPatient.adress.street);
            broj.SelectedText = Convert.ToString(selectedPatient.adress.streetNumber);
            grad.SelectedIndex = (int)selectedPatient.adress.city;  
            drzava.SelectedIndex = (int)selectedPatient.adress.country;


            //za karton
           /* imeText.SelectedText = selectedRecord.name;
            prezimeText.SelectedText = selectedRecord.surname;
            jmbgText.SelectedText = selectedRecord.jmbg;
            pol.SelectedIndex = (int)selectedRecord.gender; //ov
            brKnjText.SelectedText = Convert.ToString(selectedRecord.idHealthCard);
            brKarText.SelectedText = Convert.ToString(selectedRecord.medicalRecordId); //id = br Kartona
            alergeni.SelectedText = selectedRecord.alergens;
            krvnaGrupa.SelectedIndex = (int)selectedRecord.bloodType; */
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
            promeniP.occupation = zanimanjeText.Text;
            promeniP.insurence = osiguraniktText.Text;
            promeniP.gender = (Gender)pol.SelectedIndex;    //ovako ide za combo box
            promeniP.telephoneNumber = brText.Text;

            promeniP.PatientId = Convert.ToInt16(brKarText.Text);
            
            promeniP.IdHealthCard = Convert.ToInt16(brKnjText.Text);
            promeniP.healthCareCategory = (HealthCareCategory)zastitaText.SelectedIndex;
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
            promeniM.idHealthCard = Convert.ToInt16(brKnjText.Text);
            promeniM.healthCareCategory= (HealthCareCategory)zastitaText.SelectedIndex;
            promeniM.bloodType = (BloodType)krvnaGrupa.SelectedIndex;
            promeniM.alergens = alergeni.Text;

            mfs.Delete(izbrisiM);
            mfs.Save(promeniM);




            /* listPatient[index]= new Patient(promeniP.name,
             promeniP.surname,
              promeniP.telephoneNumber,
             promeniP.jmbg,

             promeniP.gender,
             promeniP.birthdate,
             Convert.ToInt16(promeniP.patientId),
               promeniP.healthCareCategory,
             promeniP.idHealthCard,
             promeniP.occupation,

             promeniP.insurence,
             promeniP.adress.street,
             Convert.ToInt16(promeniP.adress.streetNumber),
             (int)promeniP.adress.city,
             (int)promeniP.adress.country); */


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
