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

       

    }
}
