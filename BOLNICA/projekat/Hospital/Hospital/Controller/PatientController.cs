using Hospital.DTO;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class PatientController
    {
        private PatientService patientService;


        public PatientController()
        {
            patientService = new PatientService();

        }

        public ObservableCollection<PatientDTO> loadBlockedPatients()
        {
            return patientService.loadBlockedPatients();
        }

        public void odblokirajPacijenta(PatientDTO patient)
        {
            patientService.odblokirajPacijenta(patient);

        }

        public ObservableCollection<PatientDTO> loadGuests()
        {
            return patientService.loadGuests();
        }

        public ObservableCollection<PatientDTO> loadAllPatients()
        {
            return patientService.loadAllPatients();
        }

        public ObservableCollection<PatientDTO> loadRegistred()
        {
            return patientService.loadRegistred();
        }

        public void izmeniPacijenta(PatientDTO patient)
        {
            patientService.izmeniPacijenta(patient);
        }

        public void obrisiPacijenta(PatientDTO patient)
        {
            patientService.obrisiPacijenta(patient);
        }
        
        public void save(PatientDTO newPatient)
        {
            patientService.save(newPatient);
        }
    }
}
