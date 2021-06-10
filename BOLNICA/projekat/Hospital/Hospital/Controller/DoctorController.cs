using Hospital.DTO;
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
                DoctorDTO doctor = new DoctorDTO(d.Id, d.name, d.surname, d.TelephoneNumber, d.jmbg, d.gender, d.BirthdayDate, d.adress, d.SpecializationType);
                doctors.Add(doctor);

            }
            return doctors;
        }
    }
}
