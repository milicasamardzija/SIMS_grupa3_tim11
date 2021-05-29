using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class PatientService
    {
        private IPatientFileStorage patientStorage;


        public PatientService()
        {
            patientStorage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");

        }

        public ObservableCollection<PatientDTO> loadBlockedPatients()
        {
            ObservableCollection<PatientDTO> blockedPatients = new ObservableCollection<PatientDTO>();
            ObservableCollection<Patient> loadedPatients = new ObservableCollection<Patient>(patientStorage.GetAll());

            foreach (Patient p in loadedPatients)
            {
                if(p.banovan == true)
                {
                    blockedPatients.Add(new PatientDTO(p.Name, p.Surname, p.telephoneNumber, p.Jmbg, p.Gender, p.birthdayDate, p.Id, p.HealthCareCategory, p.IdHealthCard, p.Occupation, p.Insurence, p.adress, p.banovan));
                }
            }

            return blockedPatients;
        }
        public void odblokirajPacijenta(PatientDTO patient)
        {
            List<Patient> patients = patientStorage.GetAll();
            foreach(Patient p in patients)
            {
                if(p.Id == patient.Id)
                {
                    
                    Patient unblocked = new Patient(patient.Name, patient.Surname, patient.TelephoneNumber, patient.Jmbg, patient.Gender, patient.BirthdayDate, patient.Id, patient.HealthCareCategory, patient.IdHealthCard, patient.Occupation, patient.Insurence, patient.Adress);
                    patientStorage.Delete(p);
                    patientStorage.Save(unblocked);
                    break;
                }
            }
           
        }
    }
}
