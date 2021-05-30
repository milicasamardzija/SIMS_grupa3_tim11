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

        public List<Checkup> getCheckupDoctors(int idDoctor) 
        {
            List<Checkup> checkups = new List<Checkup>();
             return checkups = service.getCheckupDoctors(idDoctor);
           
            
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

        /*public List<CheckupDTO> getAllCheckups()
        {
            List<CheckupDTO> checkups = new List<CheckupDTO>();
            foreach (Checkup checkup in service.getAllCheckups())
            {
                checkups.Add(new CheckupDTO(checkup.Id, checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom, checkup.Type));
            }
            return checkups;
        }*/


        public void save(Checkup checkup)
        {
            service.save(checkup);
        }
        
        public void DeleteById(int id)
        {
            service.deleteById(id);
        }

        public void changeCheckup(Checkup checkup)
        {
            service.changeCheckup( checkup);
        }

        public void addCheckup(CheckupDTO checkup)
        {
            service.addCheckup(new Checkup(service.generateIdCheckup(), checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom, checkup.Type));
        }

        public void createCheckup(Checkup checkup)
        {
            service.createCheckup(checkup);
        }

        public List<Room> availableRooms(DateTime dateTime)
        {
             
               return roomService.availableRooms(dateTime);
        }

        public List<Doctor> availableDoctors(DateTime date)
        {
           
            return service.getAvailableDoctors(date);
        }
    }
}
