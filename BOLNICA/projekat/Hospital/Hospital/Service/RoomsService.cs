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
        private CheckupFileStorage checkupStorage;
        public RoomsService()
        {
            renovationStorage = new RenovationFileStorage();
            checkupStorage = new CheckupFileStorage();
        }
        public void zakaziRenoviranje(RoomRenovation renovation)
        {

            if (isRoomAvailableRenovation(renovation))
            {
                renovationStorage.Save(renovation);
            } else
            {
                MessageBox.Show("Nije moguce zakazati u ovom periodu sobu!");
            }

            //TO DO: zakazati premestanje inventara
        }

       public Boolean isRoomAvailableRenovation(RoomRenovation renovation)
       {
            foreach (Checkup checkup in checkupStorage.GetAll())
            {
                 if (checkup.idRoom == renovation.IdRoom)
                 {
                     if (checkup.Date == renovation.DateBegin || checkup.Date == renovation.DateEnd)
                     {
                        return false;
                     }

                    if (checkup.Date < renovation.DateEnd && checkup.Date > renovation.DateBegin)
                    {
                        return false;
                    }
                 }
            }
            return true;
       }

        public Boolean isRoomTakenByRenovation(Checkup checkup)
        {
            foreach (RoomRenovation renovation in renovationStorage.GetAll())
            {
                if (renovation.IdRoom == checkup.idRoom)
                {
                    if (checkup.Date == renovation.DateBegin || checkup.Date == renovation.DateEnd)
                    {
                        return true;
                    }

                    if (checkup.Date < renovation.DateEnd && checkup.Date > renovation.DateBegin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
