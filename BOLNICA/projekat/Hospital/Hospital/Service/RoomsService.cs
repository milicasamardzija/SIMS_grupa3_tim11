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
        public RoomsService()
        {
            renovationStorage = new RenovationFileStorage();
            appointmentsStorage = new AppointmentFileStorage();
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
    }
}
