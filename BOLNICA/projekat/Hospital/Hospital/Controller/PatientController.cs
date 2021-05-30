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


        public List<PatientDTO> getAll()
        {
            List<PatientDTO> patients = new List<PatientDTO>();
            foreach (Patient patient in patientService.getAll())
            {
                patients.Add(new PatientDTO(patient.name, patient.surname, patient.telephoneNumber, patient.jmbg, patient.gender, patient.birthdayDate, patient.Id, patient.HealthCareCategory, patient.IdHealthCard, patient.Occupation, patient.Insurence, patient.adress,patient.banovan));
            }
            return patients;
        }

    }
}
