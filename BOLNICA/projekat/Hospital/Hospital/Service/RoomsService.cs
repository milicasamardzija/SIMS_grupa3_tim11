using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Service
{
    class RoomsService
    {
        private RenovationFileStorage renovationStorage;
        private AppointmentFileStorage appointmentsStorage;
        private RoomFileStorage roomStorage;
        private CheckupFileStorage checkupStorage;

        public RoomsService()
        {
            renovationStorage = new RenovationFileStorage();
            appointmentsStorage = new AppointmentFileStorage();
            roomStorage = new RoomFileStorage();
            checkupStorage = new CheckupFileStorage();
        }
        public void zakaziRenoviranje(RoomRenovation renovation)
        {

            if (isRoomAvailable(renovation))
            {
                renovationStorage.Save(renovation);
            } else
            {
                MessageBox.Show("Nije moguce zakazati u ovom periodu sobu!");
            }

            //TO DO: zakazati premestanje inventara
        }

       public Boolean isRoomAvailable(RoomRenovation renovation)
       {
            /* foreach (Appointment appointment in appointmentsStorage.GetAll())
             {
                 if (appointment.idRoom == renovation.idRoom)
                 {
                     if (appointment)
                     {

                     }
                 }
             }*/
            return true;
        }

        public List<Room> availableRooms(DateTime dateTime)
        {
            List<Room> availableRooms = new List<Room>();

            foreach(Room room in roomStorage.GetAll())
            {
                foreach(Checkup checkup in checkupStorage.GetAll())
                {
                    if(room.RoomId==checkup.IdRoom) 
                    {
                       if(checkup.Date!=dateTime.Date) //ovo proverava i datum i vreme
                        {
                            availableRooms.Add(room);
                        }
                       else
                        {
                            break;
                        }
                    }
                }
            }
            return availableRooms;
        }
    }
}
