﻿using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    class CheckupService
    {
       public CheckupFileStorage checkupStorage; 
        public PatientFileStorage patientsStorage;
        public DoctorFileStorage doctorStorage;

       public List<Checkup> allCheckups { get; set; }
       

        public CheckupService()
        {
            checkupStorage = new CheckupFileStorage();
            patientsStorage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
            doctorStorage = new DoctorFileStorage();

        }

        public int generateIdCheckup() 
        {
            int val = 0;

            CheckupFileStorage checkupStorage = new CheckupFileStorage();
            List<Checkup> allCheckups = new List<Checkup>();
            allCheckups= checkupStorage.GetAll(); 

            foreach (Checkup idCh in allCheckups)
            {
                foreach (Checkup c in allCheckups)
                {
                    if (val == c.IdCh)
                    {
                        ++val; //proveravam sledeci slobodan broj
                        break;
                    }
                }
            }
            return val; //vracam prvi koji je dostupan 
        }

       public List<Checkup> getCheckupDoctors(int idDoctor)
        {

            List<Checkup> checkups = checkupStorage.GetAll();
            allCheckups = checkups;

            List<Checkup> unavailableCheckups = new List<Checkup>();

            
            return getDoctorTerms(idDoctor, unavailableCheckups);

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

        public void changeCheckup(Checkup checkup)
        {
            checkupStorage.DeleteById(checkup.IdCh);
            Checkup newCheckup = new Checkup(generateIdCheckup(), checkup.IdDoctor, checkup.IdPatient, checkup.Date, 0, CheckupType.pregled);
            checkupStorage.Save(newCheckup);

        }
    }
}
