using Hospital.Model;
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
        private CheckupFileStorage checkupStorage; 
        private PatientFileStorage patientsStorage;
        private DoctorFileStorage doctorStorage;

        List<Checkup> allCheckups;
       

        public CheckupService()
        {
            checkupStorage = new CheckupFileStorage();
            patientsStorage = new PatientFileStorage();
            doctorStorage = new DoctorFileStorage();

        }

        public int generateIdCheckup() 
        {
            int val = 0;

            CheckupFileStorage checkupStorage = new CheckupFileStorage();
            List<Checkup> allCheckups = checkupStorage.GetAll(); //Ivani je jos uvek lista...

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

       public  List<Checkup> getCheckupDoctors(int idD)
        {            
            
            allCheckups = checkupStorage.GetAll(); //nasla sve checkupove 

            List<Checkup> unavailableCheckups = new List<Checkup>();

          //moze da se ekstrahuje
            foreach(Checkup c in allCheckups)
            {
                if(c.IdDoctor.Equals(idD))
                {
                    unavailableCheckups.Add(c); 
                   
                }
            }
            return unavailableCheckups;

        }

        public void saveCheckup(int idD, int idP, DateTime date)
        {

        }
    }
}
