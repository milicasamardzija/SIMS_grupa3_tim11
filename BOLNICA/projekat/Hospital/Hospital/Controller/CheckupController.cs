using Hospital.DTO;
using Hospital.Model;
using Hospital.Sekretar;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Controller
{
   public  class CheckupController
    {
        private CheckupService service =new CheckupService();
        private RoomsService roomService;

        public  CheckupController()
        {
            roomService = new RoomsService();
        }

        public List<CheckupDTO> getCheckupDoctors(int idDoctor)
        {
            List<Checkup> checkups = new List<Checkup>(service.getCheckupDoctors(idDoctor));
            List<CheckupDTO> unavailableCheckups = new List<CheckupDTO>();
            foreach (Checkup c in checkups)
            {
                CheckupDTO checkup = new CheckupDTO(c.Id, c.IdDoctor, c.IdPatient, c.Date, c.IdRoom, c.Type);
                unavailableCheckups.Add(checkup);
            }
            return unavailableCheckups; 
        }

        public List<CheckupDTO> getCheckupsPatient(int idPatient)
        {
            List<Checkup> checkups = new List<Checkup>(service.getCheckupsPatient(idPatient));
            List<CheckupDTO> availableCheckups = new List<CheckupDTO>();
            foreach (Checkup c in checkups)
            {
                CheckupDTO checkup = new CheckupDTO(c.Id, c.IdDoctor, c.IdPatient, c.Date, c.IdRoom, c.Type);
                availableCheckups.Add(checkup);
            }
            return availableCheckups;
        }
      

        public List<CheckupDTO> getAll()
        {
            List<CheckupDTO> checkups = new List<CheckupDTO>();
            foreach (Checkup checkup in service.getAll())
            {
                checkups.Add(new CheckupDTO(checkup.Id,checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom,checkup.Type));
            }
            return checkups;
        }

        public List<Checkup> getCheckupDoctorsAndTime(DateTime dateTimeBegin, DateTime dateTimeEnd, int idDoctor)
        {
            return service.getCheckupDoctorsAndTime(dateTimeBegin, dateTimeEnd, idDoctor);
        }

        public List<Checkup> getAvailableTimes(DateTime date, Doctor doctor)
        {
            List<Checkup> checkups = new List<Checkup>();
            return checkups = service.getAvailableTimes(date,doctor);
        }


        public List<CheckupDTO> getCheckupsbyDate(int idPatient)
        {
            List<Checkup> checkups = new List<Checkup>(service.getCheckupsPatient(idPatient));
            List<CheckupDTO> availableCheckups = new List<CheckupDTO>();
            foreach (Checkup c in checkups)
            {
                CheckupDTO checkup = new CheckupDTO(c.Id, c.IdDoctor, c.IdPatient, c.Date, c.IdRoom, c.Type);
                availableCheckups.Add(checkup);
            }
            return availableCheckups;
        }

        public void save(CheckupDTO checkup)
        {
            Checkup newCheckup = new Checkup(checkup.IdCh, checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom, checkup.Type);
            service.save(newCheckup);
        }
        
        public void DeleteById(int id)
        {
            service.deleteById(id);
        }

        public void changeCheckup(CheckupDTO checkup)
        {
            Checkup update = new Checkup(checkup.IdCh, checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom, checkup.Type);
            service.changeCheckup(update);
        }

        public void addCheckup(CheckupDTO checkup) //Ivanino
        {
            Checkup newCheckup = new Checkup(service.generateIdCheckup(), checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom, checkup.Type);
            service.addCheckup(newCheckup);
        }

        public void createCheckup(CheckupDTO checkup) //Sekretar kad zakazuje samo pregled 
        {
            Checkup newCheckup = new Checkup(0, checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom, CheckupType.pregled);

            service.createCheckup(newCheckup);
        }

        public List<Room> availableRooms(DateTime dateTime)
        {
               return roomService.availableRooms(dateTime);
        }

        public List<DoctorDTO> availableDoctors(DateTime date)
        {
          List<Doctor> doctors = service.getAvailableDoctors(date);
            List<DoctorDTO> availableDoctors = new List<DoctorDTO>();
            foreach(Doctor d in doctors )
            {
                DoctorDTO doctor = new DoctorDTO(d.Id, d.Name, d.Surname, d.TelephoneNumber, d.Jmbg, d.Gender, d.BirthdayDate, d.Adress, d.SpecializationType);
                availableDoctors.Add(doctor);
            }
            return availableDoctors;
        }

        public int counterOperation(DateTime start, DateTime end)
        {
            return service.counterOperation(start, end);
        }
        public int counterCheckup(DateTime start, DateTime end)
        {
            return service.counterCheckup(start, end);
        }
    }
}
