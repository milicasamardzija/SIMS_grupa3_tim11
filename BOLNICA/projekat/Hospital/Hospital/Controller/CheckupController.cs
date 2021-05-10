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

        public List<Checkup> getCheckupDoctors(int idD) 
        {
            List<Checkup> checkups = new List<Checkup>();
             return checkups = service.getCheckupDoctors(idD);
           
            
        }

        public void createCheckup(Checkup c)
        {
            service.createCheckup(c);
        }

        public List<Room> availableRooms(DateTime dateTime)
        {
             //  List<Room> availableRoom = new List<Room>();
               return roomService.availableRooms(dateTime);
        }

        public List<Doctor> availableDoctors(DateTime date)
        {
           
            return service.getAvailableDoctors(date);
        }
    }
}
