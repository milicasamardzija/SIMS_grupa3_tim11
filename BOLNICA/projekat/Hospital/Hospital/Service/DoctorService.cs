using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
   public class DoctorService
    {

        private IDoctorFileStorage doctorStorage;

        public DoctorService()
        {
            doctorStorage= new DoctorFileStorage("./../../../../Hospital/files/storageDoctor.json");

        }



        public List<Doctor> getAll()
        {
            return doctorStorage.GetAll();
        }

        //nije bila potrebna, bilo je dovoljno samo da se hardkoduju podaci
        public int numberOfDoctorsBySpecialization(String specialization)
        {
            int count = 0;
            return count;
        }

        public List<Doctor> doctorsInShift(ShiftType type)
        {
            List<Doctor> doctors = new List<Doctor>();
            List<Doctor> allDoctors = doctorStorage.GetAll(); 

            foreach(Doctor d in allDoctors)
            {
                
                if(d.Shift.Type == type)
                {
                    doctors.Add(d);
                }
            }
            return doctors;
        }
    }
}
