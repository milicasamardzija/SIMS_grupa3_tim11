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
        private StaticInvnetoryMovementFileStorage inventoryMovementStorage;
        private RoomInventoryFileStorage roominventoryStorage;
        private InventoryFileStorage inventoryStorage;
        private StaticInvnetoryMovementFileStorage staticInventoryStorage;
        public RoomsService()
        {
            renovationStorage = new RenovationFileStorage();
            checkupStorage = new CheckupFileStorage();
            inventoryMovementStorage = new StaticInvnetoryMovementFileStorage();
            roominventoryStorage = new RoomInventoryFileStorage();
            inventoryStorage = new InventoryFileStorage();
            staticInventoryStorage = new StaticInvnetoryMovementFileStorage();
        }
        public void zakaziRenoviranje(RoomRenovation renovation)
        {

            if (isRoomAvailableRenovation(renovation))
            {
                renovationStorage.Save(renovation);
                moveInventoryForRenovation(renovation);
            } else
            {
                RenoviranjeOdbijeno odbijeno = new RenoviranjeOdbijeno();
                odbijeno.Show();
            }
        }

       /* public Boolean hasNoRenovationScheduled(RoomRenovation renovation)
        {
            foreach (RoomRenovation renov in renovationStorage.GetAll())
            {
                if (renovation.IdRoom == renov.IdRoom && renovation.DateBegin.Date == renov.DateBegin.Date)
                {
                    return false;
                }
                if (renovation.IdRoom == renov.IdRoom && renovation.DateEnd.Date == renov.DateEnd.Date)
                {
                    return false;
                }
                if (renovation.IdRoom == renov.IdRoom && renovation.DateBegin.Date < renov.DateEnd.Date &&)
                {
                    return false;
                }
            }
            return true;
        }*/

        public void moveInventoryForRenovation(RoomRenovation renovation)
        {
             foreach (RoomInventory roomInv in roominventoryStorage.GetAll())
             {
                 if (roomInv.IdRoom == renovation.IdRoom)
                 {
                     foreach (Inventory inventory in inventoryStorage.GetAll())
                     {
                         if (roomInv.IdInventory == inventory.InventoryId) {
                             if (inventory.Type == InventoryType.staticki)
                             {
                                staticInventoryStorage.Save(new StaticInventoryMovement(-1, renovation.IdRoom, inventory.InventoryId, roomInv.Quantity, renovation.DateBegin));
                                staticInventoryStorage.Save(new StaticInventoryMovement(renovation.IdRoom, -1, inventory.InventoryId, roomInv.Quantity, renovation.DateEnd));
                            }
                         }
                     }
                 }
             } 
        }

        public Boolean isRoomAvailableInventoryMovement(StaticInventoryMovement movement)
        {
            foreach (Checkup checkup in checkupStorage.GetAll())
            {
                if (checkup.idRoom == movement.RoomInId)
                {
                    if (checkup.Date == movement.Date)
                    {
                        return false;
                    }
                    if (checkup.Date.AddMinutes(checkup.Duration) == movement.Date)
                    {
                        return false;
                    }
                    if ( movement.Date > checkup.Date && movement.Date < checkup.Date.AddMinutes(checkup.Duration))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public Boolean isRoomAvailableRenovation(RoomRenovation renovation)
       {
            foreach (Checkup checkup in checkupStorage.GetAll())
            {
                 if (checkup.idRoom == renovation.IdRoom)
                 {
                     if (checkup.Date.Date == renovation.DateBegin.Date)
                     {
                        return false;
                     }

                    if (checkup.Date.Date == renovation.DateEnd.Date)
                    {
                        return false;
                    }

                    if (checkup.Date.Date < renovation.DateEnd.Date && checkup.Date.Date > renovation.DateBegin.Date)
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
                    if (checkup.Date == renovation.DateBegin)
                    {
                        return true;
                    }

                    if (checkup.Date == renovation.DateEnd)
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
