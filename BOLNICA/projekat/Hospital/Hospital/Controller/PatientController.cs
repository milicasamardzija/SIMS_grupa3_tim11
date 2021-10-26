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

        public List<PatientDTO> loadBlockedPatients()
        {
            return patientService.loadBlockedPatients();
        }

        public void unblockPatient(PatientDTO patient)
        {
            patientService.unblockPatient(patient);

        }



        public List<PatientDTO> getAll()
        {
            List<PatientDTO> patients = new List<PatientDTO>();
            foreach (Patient patient in patientService.getAll())
            {
                patients.Add(new PatientDTO(patient.Name, patient.Surname, patient.TelephoneNumber, patient.Jmbg, patient.Gender, patient.BirthdayDate, patient.Id, patient.HealthCareCategory, patient.IdHealthCard, patient.Occupation, patient.Insurence, patient.Adress,patient.banovan));
            }
            return patients;
        }


        public List<PatientDTO> loadGuests()
        {
            return patientService.loadGuests();
        }

        public List<PatientDTO> loadAllPatients()
        {
            return patientService.loadAllPatients();
        }

        public List<PatientDTO> loadRegistred()
        {
            return patientService.loadRegistred();
        }

        public void editPatient(PatientDTO patient)
        {
            patientService.editPatient(patient);
        }

        public void deletePatient(PatientDTO patient)
        {
            patientService.deletePatient(patient);
        }
        
        public void save(PatientDTO newPatient)
        {
            patientService.save(newPatient);
        }

        public List<PatientDTO> patientBySurname(String surname)
        {
           return patientService.patientBySurname(surname);
        }
    }
}
