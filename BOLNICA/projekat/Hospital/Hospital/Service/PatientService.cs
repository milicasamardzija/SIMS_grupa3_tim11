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

        public void save(Patient patient)
        {
            patientStorage.Save(patient);
        }

        public List<Patient> getAll()
        {
            return patientStorage.GetAll();
        }

        public List<PatientDTO> loadBlockedPatients()
        {
            List<PatientDTO> blockedPatients = new List<PatientDTO>();
            List<Patient> loadedPatients = patientStorage.GetAll();

            foreach (Patient p in loadedPatients)
            {
                if (p.banovan == true)
                {
                    blockedPatients.Add(new PatientDTO(p.Name, p.Surname, p.TelephoneNumber, p.Jmbg, p.Gender, p.BirthdayDate, p.Id, p.HealthCareCategory, p.IdHealthCard, p.Occupation, p.Insurence, p.Adress, p.banovan));
                }
            }

            return blockedPatients;
        }
        public void odblokirajPacijenta(PatientDTO patient)
        {
            List<Patient> patients = patientStorage.GetAll();
            foreach (Patient p in patients)
            {
                if (p.Id == patient.Id)
                {
                    Patient unblocked = new Patient(patient.Name, patient.Surname, patient.TelephoneNumber, patient.Jmbg, patient.Gender, patient.BirthdayDate, patient.Id, patient.HealthCareCategory, patient.IdHealthCard, patient.Occupation, patient.Insurence, patient.Adress);
                    patientStorage.DeleteById(p.Id);
                    patientStorage.Save(unblocked);
                    break;
                }
            }

        }

        public List<PatientDTO> loadAllPatients()
        {
            List<PatientDTO> allPatients = new List<PatientDTO>();
            List<Patient> loaded = patientStorage.GetAll();
            foreach(Patient p in loaded)
            {
                allPatients.Add(new PatientDTO(p.Name, p.Surname, p.TelephoneNumber, p.Jmbg, p.Gender, p.BirthdayDate, p.Id, p.HealthCareCategory, p.IdHealthCard, p.Occupation, p.Insurence, p.Adress, p.banovan));
            }
            return allPatients;
        }

        public List<PatientDTO> loadGuests()
        {
            List<Patient> allPatients = patientStorage.GetAll();
            List<PatientDTO> guests = new List<PatientDTO>();
            foreach (Patient p in allPatients)
            {
                if (p.guest == true)
                {
                    guests.Add(new PatientDTO(p.Name, p.Surname, p.TelephoneNumber, p.Jmbg, p.Gender, p.BirthdayDate, p.Id));
                }
            }
            return guests;
        }

        public List<PatientDTO> loadRegistred()
        {
            List<Patient> allPatients = patientStorage.GetAll();
            List<PatientDTO> registred = new List<PatientDTO>();
            foreach (Patient p in allPatients)
            {
                if (p.guest == false)
                {
                    registred.Add(new PatientDTO(p.Name, p.Surname, p.TelephoneNumber, p.Jmbg, p.Gender, p.BirthdayDate, p.Id, p.HealthCareCategory, p.IdHealthCard, p.Occupation, p.Insurence, p.Adress, p.banovan));
                }
            }
            return registred;
        }

        public void izmeniPacijenta(PatientDTO patient)
        {
            List<Patient> allPatients = patientStorage.GetAll();
            foreach (Patient p in allPatients)
            {
                if (p.Id == patient.Id)
                {
                    p.Name = patient.Name;
                    p.Surname = patient.Surname;
                    p.BirthdayDate = patient.BirthdayDate;
                    p.Jmbg = patient.Jmbg;
                    p.Occupation = patient.Occupation;
                    p.Insurence = patient.Insurence;
                    p.Gender = patient.Gender;
                    p.TelephoneNumber = patient.TelephoneNumber;
                    p.Id = patient.Id;
                    p.IdHealthCard = patient.IdHealthCard;
                    p.HealthCareCategory = patient.HealthCareCategory;
                    p.Adress = patient.Adress;

                    break;
                }
            }
            patientStorage.SaveAll(allPatients);
        }

        public void obrisiPacijenta(PatientDTO patient)
        {
            foreach (Patient p in patientStorage.GetAll())
            {
                if (p.Id == patient.Id)
                {
                    int idPatient = p.Id;
                    patientStorage.DeleteById(idPatient);
                }
            }
        }

        public int generisiId()
        {
            int ret = 0;
            List<Patient> allPatients = patientStorage.GetAll();

            foreach (Patient patient in allPatients)
            {
                foreach (Patient p in allPatients)
                {
                    if (ret == p.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public void save(PatientDTO patient)
        {
            Patient newPatient = new Patient(patient.Name, patient.Surname, patient.TelephoneNumber, patient.Jmbg, patient.Gender, patient.BirthdayDate, generisiId(), patient.HealthCareCategory, patient.IdHealthCard, patient.Occupation, patient.Insurence, patient.Adress);
            patientStorage.Save(newPatient);
        }

        public List<PatientDTO> patientBySurname(String surname)
        {
            List<Patient> all = patientStorage.patientBySurname(surname);
            List<PatientDTO> filtrated = new List<PatientDTO>();
            foreach (Patient p in all)
            {
                PatientDTO nadjen = new PatientDTO(p.Name, p.Surname, p.TelephoneNumber, p.Jmbg, p.Gender,p.BirthdayDate, p.Id, p.HealthCareCategory, p.IdHealthCard, p.Occupation, p.Insurence, p.Adress, p.banovan);
                filtrated.Add(nadjen);
            }
            return filtrated;
        }
    }
}