using Hospital.DTO;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{

    

   public class DoctorController
    {
        public DoctorService doctorService;


       public DoctorController()
        {
            doctorService = new DoctorService();

        }


        public List<DoctorDTO> getAll()
        {
            List<Doctor> all = new List<Doctor>(doctorService.getAll());
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            foreach(Doctor d in all)
            {
                DoctorDTO doctor = new DoctorDTO(d.Id, d.Name, d.Surname, d.TelephoneNumber, d.Jmbg, d.Gender, d.BirthdayDate, d.Adress, d.SpecializationType, d.Shift, d.Vacation);
                doctors.Add(doctor);

            }
            return doctors;
        }

        public List<DoctorDTO> doctorInShift(ShiftType type)
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            List<Doctor> founded = doctorService.doctorsInShift(type);
            foreach (Doctor d in founded)
            {
                DoctorDTO doctor = new DoctorDTO(d.Id, d.Name, d.Surname, d.TelephoneNumber, d.Jmbg, d.Gender, d.BirthdayDate, d.Adress, d.SpecializationType, d.Shift, d.Vacation);
                doctors.Add(doctor);
            }
            return doctors;

        }
    }
}
