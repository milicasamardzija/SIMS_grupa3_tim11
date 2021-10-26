using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
   public class VacationService
    {
        private IDoctorFileStorage doctorStorage;
        public List<DateTime> lisOfFreeDays;
        public VacationService()
        {
            doctorStorage = new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");
            lisOfFreeDays = daysFree();
         
        }


        public void countFreeDays(Doctor doctor, DateTime start, DateTime end)
        {
            Doctor doctorWithRequst  = doctorStorage.FindById(doctor.Id);
            List<DateTime> dates = new List<DateTime>();
        
        }

        
        public List<DateTime> daysFree()
        {
              List<DateTime> lisOfDays = new List<DateTime>();
            lisOfDays.Add(Convert.ToDateTime("2021 - 01 - 01T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 02 - 15T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 02 - 16T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 05 - 01T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 05 - 02T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 05 - 03T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 09 - 16T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 11 - 11T00: 00:00"));
            lisOfDays.Add(Convert.ToDateTime("2021 - 12 - 25T00: 00:00"));
            return lisOfDays;
        }

    }
}
