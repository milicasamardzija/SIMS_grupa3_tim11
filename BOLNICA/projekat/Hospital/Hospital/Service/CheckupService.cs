using Hospital.DTO;
using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;

using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class CheckupService
    {
        private CheckupFactory checkupFactory;
        public  ICheckupFileStorage checkupStorage; 
        public IPatientFileStorage patientsStorage;
        public IDoctorFileStorage doctorStorage;
        public List<Checkup> allCheckups { get; set; }
       

        public CheckupService()
        {
            checkupFactory = new CheckupFileFactory();
            // checkupStorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            checkupStorage = checkupFactory.CreateCheckup();
            patientsStorage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            doctorStorage = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
        }

        public int generateIdCheckup() 
        {
            int val = 0;
             List<Checkup> allCheckups = new List<Checkup>(checkupStorage.GetAll());

             foreach (Checkup idCh in allCheckups)
            {
                foreach (Checkup c in allCheckups)
                {
                    if (val == c.Id)
                    {
                        ++val; //proveravam sledeci slobodan broj
                        break;
                    }
                }
            }
            return val; //vracam prvi koji je dostupan 
        }

        internal List<Checkup> getCheckupDoctorsAndTime(DateTime dateBegin, DateTime dateEnd, int idDoctor)
        {
            List<Checkup> checkups = new List<Checkup>();
            foreach (Checkup checkup in checkupStorage.GetAll())
            {
                if (checkup.IdDoctor == idDoctor && checkup.Date == dateBegin)
                {
                    checkups.Add(checkup);
                } else if (checkup.IdDoctor == idDoctor && checkup.Date == dateEnd)
                {
                    checkups.Add(checkup);
                }
                else if (checkup.IdDoctor == idDoctor && checkup.Date < dateEnd && checkup.Date > dateBegin)
                {
                    checkups.Add(checkup);
                }
            }
            return checkups;
        }

        public List<Checkup> getCheckupDoctors(int idDoctor)
        {

            List<Checkup> checkups = checkupStorage.GetAll();
            allCheckups = checkups;
            List<Checkup> unavailableCheckups = new List<Checkup>();
            return getDoctorTerms(idDoctor, unavailableCheckups);

        }

        public List<Checkup> getCheckupsPatient(int idPatient)
        {
            List<Checkup> checkups = checkupStorage.GetAll();
            List<Checkup> availableCheckups = new List<Checkup>();
            foreach (Checkup appointment in checkups)
            {

                if (appointment.IdPatient == idPatient)
                {

                    availableCheckups.Add(appointment);
                }
            }
            return availableCheckups;
        }
        

private List<Checkup> getDoctorTerms(int idDoctor, List<Checkup> unavailableCheckups)
        {
            foreach (Checkup c in allCheckups)
            {
                if (c.IdDoctor.Equals(idDoctor))
                {
                    unavailableCheckups.Add(c);
                }
            }
            return unavailableCheckups;
        }

        public List<Checkup> getCheckupsbyDate(int idPatient)
        {
            List<Checkup> checkups = checkupStorage.GetAll();
            List<Checkup> availableCheckups = new List<Checkup>();
            foreach (Checkup appointment in checkups)
            {

                if (appointment.IdPatient == idPatient)
                {
                    if (DateTime.Now > appointment.Date)
                    {
                      availableCheckups.Add(appointment);
                    }
                }
            }
            return availableCheckups;
        }

        public void createCheckup(Checkup checkup)
        {
            Checkup newCheckup = new Checkup(generateIdCheckup(), checkup.IdDoctor, checkup.IdPatient, checkup.Date, 0, CheckupType.pregled);
            checkupStorage.Save(newCheckup);
        }

        public List<Doctor> getAvailableDoctors(DateTime date)
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (Checkup checkup in checkupStorage.GetAll()) 
            {
                foreach(Doctor d in doctorStorage.GetAll())
                {
                    if(checkup.Date != date.Date)
                    {
                        doctors.Add(d);
                    }
                }
            }
            return doctors;
        }

        public List<Checkup> getAvailableTimes(DateTime date,Doctor doctor)
        {
            List<Checkup> termini = new List<Checkup>();
            
            foreach (Patient patient in patientsStorage.GetAll())
            {
                foreach (Checkup termin in checkupStorage.GetAll())
                {
                   if (doctor.Id == termin.IdDoctor)
                    {
                        if (termin.Date.Date.Equals(date))
                        {
                            termini.Add(termin);
                        }
                    }
                  
                    if (patient.Id == termin.Patient.Id)
                    {
                        if (termin.Date.Date.Equals(date))
                        {
                            termini.Add(termin);
                        }
                    }
                }

            }
            return termini;
        }

      

        public void changeCheckup(Checkup checkup)
        {
            checkupStorage.DeleteById(checkup.Id);  //ostavljam njego Id jer je ipak izmena u pitanju
            Checkup newCheckup = new Checkup(checkup.Id, checkup.IdDoctor, checkup.IdPatient, checkup.Date, 0, CheckupType.pregled);
            checkupStorage.Save(newCheckup);

        }

        public List<Checkup> getAll()
        {
            return checkupStorage.GetAll();
        }
        
        public void deleteById(int id)
        {
            
            checkupStorage.DeleteById(id);
        }

        public void save(Checkup checkup)
        {
            checkupStorage.Save(checkup);
        }


        public int counterOperation(DateTime start, DateTime end)
        {
            List<Checkup> allCheckups = checkupStorage.GetAll();
            int counter = 0;

            foreach (Checkup c in allCheckups)
            {
                if (c.Type == CheckupType.operacija)
                {
                    if(c.Date >= start && c.Date <= end) 
                    counter += 1;
                }
            }
            return counter;
        }

        public int counterCheckup(DateTime start, DateTime end)
        {
            List<Checkup> allCheckups = checkupStorage.GetAll();
            int counter = 0;

            foreach (Checkup c in allCheckups)
            {
                if (c.Type == CheckupType.pregled)
                {
                 if (c.Date >= start && c.Date<= end)
                        counter += 1;
                }
            }
            return counter;
        }


        public void addCheckup(Checkup checkup)
        {
            Checkup newCheckup = new Checkup(generateIdCheckup(), checkup.IdPatient, checkup.IdDoctor, checkup.Date, checkup.IdRoom, checkup.Type);
            checkupStorage.Save(newCheckup);
        }

    }
}
